create procedure [dbo].[BalanceSheetBrowse] @filter xml
as
begin
	set nocount on;

	declare @BalanceDate date, @OrganizationId TIdentifier;

	select
		@BalanceDate = T.c.value('BalanceDate[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @BalanceDate is null
		set @BalanceDate = getdate();

	declare @BalanceSheet table
			(
				[LineId] int not null,
				[AssetValue] decimal(18,6) null,
				[LiabilityValue] decimal(18, 6) null
			);
	declare @MoneyOperationState table ( [State] tinyint not null );
	insert into @MoneyOperationState ([State]) select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/MoneyOperationState') as T(c);

	declare @InvoiceState table ([State] tinyint not null);
	insert into @InvoiceState ([State]) select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/InvoiceState') as T(c);

	with [A] ([Id], [State], [DocumentDate], [ParentId], [OrganizationId], [BankAccountId], [CashAccount], [MoneyOperationTypeId], [MoneyOperationDirection], 
			  [BudgetId], [OperatingBudgetId], [BudgetItemGroupId], [BudgetItemId], [AccountId], [EmployeeId], [Value], [VATValue]) as
	(
		select
			[MoneyOperation].[Id],
			[MoneyOperation].[State],
			[MoneyOperation].[DocumentDate],
			[MoneyOperation].[ParentId],
			[MoneyOperation].[OrganizationId],
			[MoneyOperation].[BankAccountId],
			cast([BankAccount].[CashAccount] as int),
			[MoneyOperation].[MoneyOperationTypeId],
			[MoneyOperation].[MoneyOperationDirection],
			[MoneyOperation].[BudgetId],
			[MoneyOperation].[OperatingBudgetId],
			[MoneyOperation].[BudgetItemGroupId],
			[MoneyOperation].[BudgetItemId],
			[MoneyOperation].[AccountId],
			[MoneyOperation].[EmployeeId],
			[MoneyOperation].[Value],
			[MoneyOperation].[VATValue]
		from
			[MoneyOperation] inner join [BankAccount]
				on ([MoneyOperation].[BankAccountId] = [BankAccount].[Id])
		where
			(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
		and
			[MoneyOperation].[MoneyOperationTypeId] != 8 -- возврат в кассу
		and 
			[MoneyOperation].[DocumentDate] <= @BalanceDate
		and
			[MoneyOperation].[State] in (select [State] from @MoneyOperationState)
		union all
		select
			[MoneyOperation].[Id],
			[MoneyOperation].[State],
			[MoneyOperation].[DocumentDate],
			[MoneyOperation].[ParentId],
			[MoneyOperation].[OrganizationId],
			[MoneyOperation].[BankAccountId],
			1,
			4, --[MoneyOperation].[MoneyOperationTypeId],
			1, --[MoneyOperation].[MoneyOperationDirection],
			[Parent].[BudgetId],
			[Parent].[OperatingBudgetId],
			[Parent].[BudgetItemGroupId],
			[Parent].[BudgetItemId],
			[Parent].[AccountId],
			[Parent].[EmployeeId],
			[MoneyOperation].[Value],
			[MoneyOperation].[VATValue]
		from
			[MoneyOperation] inner join [MoneyOperation] as [Parent]
				on ([MoneyOperation].[ParentId] = [Parent].[Id])
		where
			[MoneyOperation].[ParentId] is not null 
		and
			[Parent].[MoneyOperationTypeId] = 4 -- под отчет
		and 
			[MoneyOperation].[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
		and
			[MoneyOperation].[State] in (select [State] from @MoneyOperationState)
	)
	insert into @BalanceSheet
		([LineId], [AssetValue], [LiabilityValue])
	select
		[CashAccount] + 1,	-- остатки дс в банке и кассе
		sum([MoneyOperationDirection] * [Value]),
		null
	from
		[A]
	group by
		[CashAccount]
	union all
	select
		3,			-- деньги выданные под отчет
		-sum([MoneyOperationDirection] * [Value]),
		null
	from
		[A]
	where	
		[CashAccount] = 1 and [MoneyOperationTypeId] = 4
	union all
	select
		4,			-- обязательства по кредитам
		-sum(case when [MoneyOperationTypeId] in (10, 11) then [MoneyOperationDirection] * [Value] else 0 end),
		sum(case when [MoneyOperationTypeId] in (6, 9) then [MoneyOperationDirection] * [Value] else 0 end)
	from
		[A]
	where	
		[MoneyOperationTypeId] in (6, 9, 10, 11)
		
	insert into @BalanceSheet
		([LineId], [AssetValue])
	select
		5,			-- остатки товара на складе по себестоимости
		sum(([IncomingAmount] - [OutgoingAmount]) * [Cost])
	from
		[InventoryOperation]
	where
		[OperationDate] <= @BalanceDate
	and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId);


	with [PI] ([Id], [InvoiceType], [AccountId], [OrganizationId], [BudgetItemGroupId], [BudgetItemId], [BudgetId], [Value]) as 
	(
		select
			[Id],
			1 as [PurchaseInvoiceType],
			[AccountId],
			[OrganizationId],
			[BudgetItemGroupId],
			[BudgetItemId],
			[BudgetId],
			[Value]
		from
			[PurchaseInvoice]
		where
			[BudgetId] is not null
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @InvoiceState)
		union all
		select
			[Id],
			2 as [PurchaseInvoiceType],
			[AccountId],
			[OrganizationId],
			[BudgetItemGroupId],
			[BudgetItemId],
			[OperatingBudgetId],
			[Value]
		from
			[PurchaseInvoice]
		where
			[OperatingBudgetId] is not null
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @InvoiceState)
		union all
		select
			[Id],
			3 as [PurchaseInvoiceType],
			[AccountId],
			[OrganizationId],
			[BudgetItemGroupId],
			[BudgetItemId],
			null,
			[Value]
		from
			[PurchaseInvoice]
		where
			([BudgetId] is null and [OperatingBudgetId] is null)
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @InvoiceState)
	), 
	[P] ([Id], [PaymentType], [OrganizationId], [AccountId], [PurchaseInvoiceId], [Value]) as
	(
		select
			[Id],
			1 as [PaymentType],	
			[OrganizationId],
			[AccountId],
			[PurchaseInvoiceId],
			[Value]
		from
			[MoneyOperation]
		where
			[MoneyOperationTypeId] = 2
		and
			[BudgetId] is not null
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @MoneyOperationState)
		union all
		select
			[Id],
			2,	
			[OrganizationId],
			[AccountId],
			[PurchaseInvoiceId],
			[Value]
		from
			[MoneyOperation]
		where
			[MoneyOperationTypeId] = 2
		and
			[OperatingBudgetId] is not null
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @MoneyOperationState)
		union all
		select
			[Id],
			3,	
			[OrganizationId],
			[AccountId],
			[PurchaseInvoiceId],
			[Value]
		from
			[MoneyOperation]
		where
			[MoneyOperationTypeId] = 2
		and
			([BudgetId] is null and [OperatingBudgetId] is null)
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @MoneyOperationState)
	),
	[PIG] ([InvoiceType], [AccountId], [Value]) as 
	(
		select
			[InvoiceType],
			[AccountId],
			sum([Value])
		from
			[PI]
		group by
			[InvoiceType],
			[AccountId]
	),
	[PG] ([PaymentType], [AccountId], [Value]) as
	(
		select
			[PaymentType],
			[AccountId],
			sum([Value])
		from
			[P]
		group by
			[PaymentType],
			[AccountId]
	),
	[R] ([Group], [AccountId], [AssetValue], [LiabilityValue]) as
	(
		select
			coalesce([PIG].[InvoiceType],[PG].[PaymentType]) as [BudgetType],
			coalesce([PIG].[AccountId], [PG].[AccountId]) as [AccountId],
			case when isnull([PG].[Value], 0) > isnull([PIG].[Value], 0) then isnull([PG].[Value], 0) - isnull([PIG].[Value], 0) else 0 end,
			case when isnull([PG].[Value], 0) <= isnull([PIG].[Value], 0) then isnull([PIG].[Value], 0) - isnull([PG].[Value], 0) else 0 end
		from
			[PIG] full outer join [PG]
				on ([PIG].[InvoiceType] = [PG].[PaymentType] and [PIG].[AccountId] = [PG].[AccountId])
	)
	insert into @BalanceSheet
		([LineId], [AssetValue], [LiabilityValue])
	select
		[Group] + 5,
		sum([AssetValue]),
		sum([LiabilityValue])
	from
		[R]
	group by
		[Group];

	with [P] ([AccountId], [Value]) as
	(
		select 
			[AccountId],
			sum([Value]) 
		from 
			[MoneyOperation]
		where
			[MoneyOperationTypeId] = 3
		and
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @MoneyOperationState)
		group by
			[AccountId]
	),
	[I] ([AccountId], [Value]) as
	(
		select
			[AccountId],
			sum([Value])
		from
			[SalesInvoice]
		where
			[DocumentDate] <= @BalanceDate
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			[State] in (select [State] from @InvoiceState)
		group by
			[AccountId]
	),
	[R] ([AccountId], [AssetValue], [LiabilityValue]) as
	(
		select
			coalesce([P].[AccountId], [I].[AccountId]),
			case when isnull([P].[Value], 0) <= isnull([I].[Value], 0) then isnull([I].[Value], 0) - isnull([P].[Value], 0) else 0 end,
			case when isnull([P].[Value], 0) > isnull([I].[Value], 0) then isnull([P].[Value], 0) - isnull([I].[Value], 0) else 0 end
		from
			[P] full outer join [I]
				on ([P].[AccountId] = [I].[AccountId])
	)
	insert into @BalanceSheet
		([LineId], [AssetValue], [LiabilityValue])
	select
		9,
		sum([R].[AssetValue]),
		sum([R].[LiabilityValue])
	from
		[R];

	select 
		[LineId],
		isnull([AssetValue], 0) as [AssetValue],
		isnull([LiabilityValue], 0) as [LiabilityValue]
	from 
		@BalanceSheet as [BalanceSheetLine]
	for xml auto, root('ArrayOfBalanceSheetLine');

	return 0;
end;

go

grant execute on [dbo].[BalanceSheetBrowse] to [public];
go