create procedure [dbo].[PurchaseInvoiceBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256),
			@OrganizationId TIdentifier, @AccountId TIdentifier, @BudgetId TIdentifier, @OperatingBudgetId TIdentifier,
			@IsCash bit, @ServiceRequestId TIdentifier, @ResponsibleEmployeeId TIdentifier,
			@PeriodStart date, @PeriodEnd date, @BudgetItemGroupIdIsSet bit, @BudgetItemGroupId int, @BudgetItemIdIsSet bit, @BudgetItemId int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@BudgetId = T.c.value('BudgetId[1]', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('OperatingBudgetId[1]', 'TIdentifier'),
		@ServiceRequestId = T.c.value('ServiceRequestId[1]', 'TIdentifier'),
		@ResponsibleEmployeeId = T.c.value('ResponsibleEmployeeId[1]', 'TIdentifier'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@IsCash = T.c.value('IsCash[1]', 'bit'),
		@BudgetItemGroupIdIsSet = T.c.value('BudgetItemGroupIdIsSet[1]', 'bit'),
		@BudgetItemGroupId = T.c.value('BudgetItemGroupId[1]', 'int'),
		@BudgetItemIdIsSet = T.c.value('BudgetItemIdIsSet[1]', 'bit'),
		@BudgetItemId = T.c.value('BudgetItemId[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	if(@PeriodStart is null)
		set @PeriodStart = cast('0001-01-01' as date);

	if(@PeriodEnd is null)
		set @PeriodEnd = cast('9999-12-31' as date);
	with [P] ([PurchaseInvoiceId], [Value], [VATValue]) as
	(
		select
			[PurchaseInvoiceId],
			sum([Value]),
			sum([VATValue])
		from
			[dbo].[MoneyOperation]
		where
			[PurchaseInvoiceId] is not null
		group by
			[PurchaseInvoiceId]
	)
	select
		[PurchaseInvoice].[Id],
		[PurchaseInvoice].[State],
		[PurchaseInvoice].[FileAs],
		[PurchaseInvoice].[Number],
		[PurchaseInvoice].[DocumentDate],
		[PurchaseInvoice].[DueDate],
		[PurchaseInvoice].[OrganizationId],
		[PurchaseInvoice].[AccountId],
		[Budget].[ServiceRequestId],
		[ServiceRequest].[AccountId] as [ServiceRequestAccountId],
		[OperatingBudget].[DocumentDate] as [OperatingBudgetDocumentDate],
		[PurchaseInvoice].[BudgetId],
		[PurchaseInvoice].[OperatingBudgetId],
		[PurchaseInvoice].[BudgetItemGroupId],
		[PurchaseInvoice].[BudgetItemId],
		[PurchaseInvoice].[ResponsibleEmployeeId],
		[PurchaseInvoice].[Subject],
		[PurchaseInvoice].[IsCash],
		[PurchaseInvoice].[Value],
		[PurchaseInvoice].[VATValue],
		isnull([P].[Value], 0) as [PayedValue],
		[PurchaseInvoice].[VATRateId],
		isnull([P].[VATValue], 0) as [PayedVATValue],
		[PurchaseInvoice].[Comments],
		[PurchaseInvoice].[Created],
		[PurchaseInvoice].[CreatedBy],
		[PurchaseInvoice].[Modified],
		[PurchaseInvoice].[ModifiedBy],
		[PurchaseInvoice].[RowVersion]
	from
		[dbo].[PurchaseInvoice]	left outer join [Budget]
			on ([PurchaseInvoice].[BudgetId] = [Budget].[Id])
		left outer join [OperatingBudget]
			on ([PurchaseInvoice].[OperatingBudgetId] = [OperatingBudget].[Id])
		left outer join [P]
			on ([PurchaseInvoice].[Id] = [P].[PurchaseInvoiceId])
		left outer join [ServiceRequest]
			on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
	where
		([PurchaseInvoice].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [PurchaseInvoice].[OrganizationId] = @OrganizationId)
		and
		(@AccountId is null or [PurchaseInvoice].[AccountId] = @AccountId)
		and
		(@BudgetId is null or [PurchaseInvoice].[BudgetId] = @BudgetId)
		and
		(@OperatingBudgetId is null or [PurchaseInvoice].[OperatingBudgetId] = @OperatingBudgetId)
		and
		(@ServiceRequestId is null or [Budget].[ServiceRequestId] = @ServiceRequestId)
		and
		(@ResponsibleEmployeeId is null or [PurchaseInvoice].[ResponsibleEmployeeId] = @ResponsibleEmployeeId)
		and
		(@BudgetItemGroupIdIsSet = 0 or (isnull(@BudgetItemGroupId, 0) = isnull([PurchaseInvoice].[BudgetItemGroupId], 0)))
		and
		(@BudgetItemIdIsSet = 0 or (isnull(@BudgetItemId, 0) = isnull([PurchaseInvoice].[BudgetItemId], 0)))
		and
		(@Id is null or [PurchaseInvoice].[Id] = @Id)
		and
		(@AllStates = 1 or [PurchaseInvoice].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
