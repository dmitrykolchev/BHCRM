CREATE PROCEDURE [dbo].[ConsolidatedMoneyOperationBrowse] @filter xml
AS
begin
	set nocount on;

	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier, @BankAccountId TIdentifier;

	select
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

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
			([MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
			[MoneyOperation].[MoneyOperationTypeId] != 8 -- возврат в кассу
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
			(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
		and
			([MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	),
	[M] ([ViewGroup], [CashAccount], [MoneyOperationDirection], [BudgetItemGroupId], [BudgetItemId], [Value]) as 
	(
		select 
			1 as [ViewGroup],
			[CashAccount],
			0,
			null as [BudgetItemGroupId],
			null as [BudgetItemId],
			sum([MoneyOperationDirection] * [Value])
		from 
			[A]
		where
			DocumentDate < @PeriodStart
		group by
			[CashAccount]
		union all
		select 
			2,
			0,
			[MoneyOperationDirection],
			[BudgetItemGroupId],
			[BudgetItemId],
			sum([Value])
		from 
			[A]
		where
			[DocumentDate] >= @PeriodStart and [DocumentDate] <= @PeriodEnd
		and
			[MoneyOperationTypeId] not in (4, 6, 9, 10, 11)
		group by
			[MoneyOperationDirection],
			[BudgetItemGroupId],
			[BudgetItemId]
		union all
		select 
			3 as [ViewGroup],
			[CashAccount],
			0,
			null as [BudgetItemGroupId],
			null as [BudgetItemId],
			sum([MoneyOperationDirection] * [Value])
		from 
			[A]
		where
			DocumentDate <= @PeriodEnd
		group by
			[CashAccount]
		union all
		select
			4,
			1,
			[MoneyOperationDirection],
			null,
			null,
			sum([Value])
		from
			[A]
		where
			[DocumentDate] > @PeriodStart and [DocumentDate] <= @PeriodEnd
		and
			[MoneyOperationTypeId] = 4
		group by
			[MoneyOperationDirection]
		union all
		select
			5,
			0,
			[MoneyOperationDirection],
			null,
			null,
			sum([Value])
		from
			[A]
		where
			[DocumentDate] > @PeriodStart and [DocumentDate] <= @PeriodEnd
		and
			[MoneyOperationTypeId] in (6, 9)
		group by
			[MoneyOperationDirection]
		union all
		select
			6,
			0,
			[MoneyOperationDirection],
			null,
			null,
			sum([Value])
		from
			[A]
		where
			[DocumentDate] > @PeriodStart and [DocumentDate] <= @PeriodEnd
		and
			[MoneyOperationTypeId] in (10, 11)
		group by
			[MoneyOperationDirection]
	)
	select
		[ViewGroup],
		[CashAccount],
		[MoneyOperationDirection],
		[BudgetItemGroupId],
		[BudgetItemId],
		[Value]
	from	
		[M] as [ConsolidatedMoneyOperationLine]
	for xml auto, root('ArrayOfConsolidatedMoneyOperationLine');

	return 0;
end

grant execute on [dbo].[ConsolidatedMoneyOperationBrowse] to [public];
go
