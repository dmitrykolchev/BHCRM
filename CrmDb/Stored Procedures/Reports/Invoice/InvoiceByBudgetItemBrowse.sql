create procedure [reports].[InvoiceByBudgetItemBrowse] @filter xml
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

	with [PI] ([BudgetItemGroupId], [BudgetItemId], [Value], [VATValue]) as
	(
		select 
			[BudgetItemGroupId],
			[BudgetItemId],
			sum([Value]),
			sum([VATValue])
		from 
			[PurchaseInvoice]
		where
			([DocumentDate] >= @PeriodStart and [DocumentDate] <= @PeriodEnd)
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		group by
			[BudgetItemGroupId],
			[BudgetItemId]
	)
	, [SI] ([BudgetItemGroupId], [BudgetItemId], [Value], [VATValue]) as 
	(
		select 
			[BudgetItemGroupId],
			[BudgetItemId],
			sum([Value]),
			sum([VATValue])
		from 
			[SalesInvoice]
		where
			([DocumentDate] >= @PeriodStart and [DocumentDate] <= @PeriodEnd)
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		group by
			[BudgetItemGroupId],
			[BudgetItemId]
	)
	, [InvoiceByBudgetItemItem] ([BudgetItemGroupId], [BudgetItemId], [Direction], [InvoiceValue], [InvoiceVATValue]) as
	(
		select
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId],
			-1,
			[PI].[Value],
			[PI].[VATValue]
		from
			[PI]
		union all
		select
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId],
			1,
			[SI].[Value],
			[SI].[VATValue]
		from
			[SI]
	)
	select
		[BudgetItemGroupId],
		[BudgetItemId],
		[Direction],
		[InvoiceValue],
		[InvoiceVATValue]
	from
		[InvoiceByBudgetItemItem]
	for xml auto, root('ArrayOfInvoiceByBudgetItemItem')

	return 0;
end
go

grant execute on  [reports].[InvoiceByBudgetItemBrowse] to [public];
go
