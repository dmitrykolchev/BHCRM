create procedure [reports].[InvoicePaymentByContragentBrowse] @filter xml
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

	with [PP] ([PurchaseInvoiceId], [PayedValue]) as 
	(
		select [PurchaseInvoiceId], sum([Value]) from [MoneyOperation] where [PurchaseInvoiceId] is not null group by [PurchaseInvoiceId]
	)
	,[PI] ([AccountId], [Value], [VATValue], [PayedValue]) as
	(
		select 
			[AccountId],
			sum([Value]),
			sum([VATValue]),
			sum([PayedValue])
		from 
			[PurchaseInvoice] left outer join [PP]
				on ([PurchaseInvoice].[Id] = [PP].[PurchaseInvoiceId])
		where
			([DocumentDate] >= @PeriodStart and [DocumentDate] <= @PeriodEnd)
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		group by
			[AccountId]
	)
	, [SP] ([SalesInvoiceId], [PayedValue]) as 
	(
		select [SalesInvoiceId], sum([Value]) from [MoneyOperation] where [SalesInvoiceId] is not null group by [SalesInvoiceId]
	)
	, [SI] ([AccountId], [Value], [VATValue], [PayedValue]) as 
	(
		select 
			[AccountId],
			sum([Value]),
			sum([VATValue]),
			sum([PayedValue])
		from 
			[SalesInvoice] left outer join [SP]
				on ([SalesInvoice].[Id] = [SP].[SalesInvoiceId])
		where
			([DocumentDate] >= @PeriodStart and [DocumentDate] <= @PeriodEnd)
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		group by
			[AccountId]
	)
	, [InvoicePaymentByContragentItem] ([AccountId], 
	                                    [PurchaseInvoiceValue], [PurchaseInvoiceVATValue], [PurchaseInvoicePayedValue], 
									    [SalesInvoiceValue], [SalesInvoiceVATValue], [SalesInvoicePayedValue]) as
	(
		select
			[Account].[Id],
			[PI].[Value],
			[PI].[VATValue],
			[PI].[PayedValue],
			[SI].[Value],
			[SI].[VATValue],
			[SI].[PayedValue]
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
		[PurchaseInvoicePayedValue],
		[SalesInvoiceValue],
		[SalesInvoiceVATValue],
		[SalesInvoicePayedValue]
	from
		[InvoicePaymentByContragentItem]
	for xml auto, root('ArrayOfInvoicePaymentByContragentItem')

	return 0;
end

go

grant execute on [reports].[InvoicePaymentByContragentBrowse] to [public];
go