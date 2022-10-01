create procedure [dbo].[SalesInvoiceBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Presentation varchar(256),
			@OrganizationId TIdentifier, @AccountId TIdentifier, @BudgetId TIdentifier, @OperatingBudgetId TIdentifier,
			@IsCash bit, @ServiceRequestId TIdentifier, @ResponsibleEmployeeId TIdentifier,
			@PeriodStart date, @PeriodEnd date, @BudgetItemGroupIdIsSet bit, @BudgetItemGroupId int, @BudgetItemIdIsSet bit, @BudgetItemId int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
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

	with [S] ([SalesInvoiceId], [Value], [VATValue]) as
	(
		select
			[SalesInvoiceId],
			sum([Value]),
			sum([VATValue])
		from
			[dbo].[MoneyOperation]
		where
			[SalesInvoiceId] is not null
		group by
			[SalesInvoiceId]
	)
	select
		[SalesInvoice].[Id],
		[SalesInvoice].[State],
		[SalesInvoice].[FileAs],
		[SalesInvoice].[Number],
		[SalesInvoice].[DocumentDate],
		[SalesInvoice].[DueDate],
		[SalesInvoice].[OrganizationId],
		[SalesInvoice].[AccountId],
		[Budget].[ServiceRequestId],
		[SalesInvoice].[BudgetId],
		[SalesInvoice].[OperatingBudgetId],
		[SalesInvoice].[BudgetItemGroupId],
		[SalesInvoice].[BudgetItemId],
		[SalesInvoice].[ResponsibleEmployeeId],
		[SalesInvoice].[Subject],
		[SalesInvoice].[IsCash],
		[SalesInvoice].[Value],
		[SalesInvoice].[VATValue],
		isnull([S].[Value], 0) as [PayedValue],
		[SalesInvoice].[VATRateId],
		isnull([S].[VATValue], 0) as [PayedVATValue],
		[SalesInvoice].[Comments],
		[SalesInvoice].[Created],
		[SalesInvoice].[CreatedBy],
		[SalesInvoice].[Modified],
		[SalesInvoice].[ModifiedBy],
		[SalesInvoice].[RowVersion]
	from
		[dbo].[SalesInvoice] left outer join [Budget]
			on ([SalesInvoice].[BudgetId] = [Budget].[Id])
		left outer join [S]
			on ([SalesInvoice].[Id] = [S].[SalesInvoiceId])
	where
		([SalesInvoice].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [SalesInvoice].[OrganizationId] = @OrganizationId)
		and
		(@AccountId is null or [SalesInvoice].[AccountId] = @AccountId)
		and
		(@BudgetId is null or [SalesInvoice].[BudgetId] = @BudgetId)
		and
		(@OperatingBudgetId is null or [SalesInvoice].[OperatingBudgetId] = @OperatingBudgetId)
		and
		(@ServiceRequestId is null or [Budget].[ServiceRequestId] = @ServiceRequestId)
		and
		(@ResponsibleEmployeeId is null or [SalesInvoice].[ResponsibleEmployeeId] = @ResponsibleEmployeeId)
		and
		(@BudgetItemGroupIdIsSet = 0 or (isnull(@BudgetItemGroupId, 0) = isnull([SalesInvoice].[BudgetItemGroupId], 0)))
		and
		(@BudgetItemIdIsSet = 0 or (isnull(@BudgetItemId, 0) = isnull([SalesInvoice].[BudgetItemId], 0)))
		and
		(@AllStates = 1 or [SalesInvoice].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
