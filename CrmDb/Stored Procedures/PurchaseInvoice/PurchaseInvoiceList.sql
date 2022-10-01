create procedure [dbo].[PurchaseInvoiceList] @filter xml
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
		[PurchaseInvoice].[Id],
		[PurchaseInvoice].[State],
		[PurchaseInvoice].[FileAs],
		[PurchaseInvoice].[Number],
		[PurchaseInvoice].[DocumentDate],
		[PurchaseInvoice].[DueDate],
		[PurchaseInvoice].[OrganizationId],
		[PurchaseInvoice].[AccountId],
		[Budget].[ServiceRequestId],
		[PurchaseInvoice].[BudgetId],
		[PurchaseInvoice].[OperatingBudgetId],
		[PurchaseInvoice].[BudgetItemGroupId],
		[PurchaseInvoice].[BudgetItemId],
		[PurchaseInvoice].[ResponsibleEmployeeId],
		[PurchaseInvoice].[Subject],
		[PurchaseInvoice].[IsCash],
		[PurchaseInvoice].[Value],
		[PurchaseInvoice].[VATRateId],
		[PurchaseInvoice].[VATValue]
	from
		[dbo].[PurchaseInvoice]	left outer join [Budget]
			on ([PurchaseInvoice].[BudgetId] = [Budget].[Id])
	where
		(@Id is null or [PurchaseInvoice].[Id] = @Id)
		and
		(@AllStates = 1 or [PurchaseInvoice].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
