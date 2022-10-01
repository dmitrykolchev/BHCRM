create procedure [reports].[InvoiceByContragentBrowse] @filter xml
as
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

	with [PI] ([AccountId], [Value], [VATValue]) as
	(
		select 
			[AccountId],
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
			[AccountId]
	)
	, [SI] ([AccountId], [Value], [VATValue]) as 
	(
		select 
			[AccountId],
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
			[AccountId]
	)
	, [InvoiceByContragentItem] ([AccountId], [PurchaseInvoiceValue], [PurchaseInvoiceVATValue], [SalesInvoiceValue], [SalesInvoiceVATValue]) as
	(
		select
			[Account].[Id],
			[PI].[Value],
			[PI].[VATValue],
			[SI].[Value],
			[SI].[VATValue]
		from
			[Account] left outer join [PI]
				on ([Account].[Id] = [PI].[AccountId])
			left outer join [SI]
				on ([Account].[Id] = [SI].[AccountId])
		where
			[PI].[Value] is not null 
			or 
			[SI].[Value] is not null
	)
	select
		[AccountId],
		[PurchaseInvoiceValue],
		[PurchaseInvoiceVATValue],
		[SalesInvoiceValue],
		[SalesInvoiceVATValue]
	from
		[InvoiceByContragentItem]
	for xml auto, root('ArrayOfInvoiceByContragentItem')

	return 0;
end
go

grant execute on [reports].[InvoiceByContragentBrowse] to [public];
go