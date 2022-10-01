create procedure [dbo].[SalesInvoiceList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

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
		[SalesInvoice].[VATRateId],
		[SalesInvoice].[VATValue]
	from
		[dbo].[SalesInvoice] left outer join [Budget]
			on ([SalesInvoice].[BudgetId] = [Budget].[Id])
	where
		(@Id is null or [SalesInvoice].[Id] = @Id)
		and
		(@AllStates = 1 or [SalesInvoice].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
