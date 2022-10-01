CREATE PROCEDURE [dbo].[CreditMoneyOperationBrowse] @filter xml
as
begin
	set nocount on;

	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier;

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

	with [R] ([ParentId], [LastPaymentDate], [Value], [VATValue]) as 
	(
		select
			[ParentId],
			max([DocumentDate]),
			sum([Value]),
			sum([VATValue])
		from
			[MoneyOperation]
		where
			[MoneyOperationTypeId] = 9
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([DocumentDate] between @PeriodStart and @PeriodEnd)
		group by
			[ParentId]
	)
	select 
		[M].[Id],
		[M].[AccountId],
		[M].[OrganizationId],
		[M].[DocumentDate],
		[M].[Number],
		[M].[Value],
		[R].[Value] as [ReturnValue],
		[R].[LastPaymentDate]
	from 
		[MoneyOperation] as [M] left outer join [R]
			on ([M].[Id] = [R].[ParentId])
	where 
		[MoneyOperationTypeId] = 6
	and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId)
	and
		([DocumentDate] between @PeriodStart and @PeriodEnd)
	for xml raw('CreditMoneyOperation'), root('ArrayOfCreditMoneyOperation');

	return 0;
end

go

grant execute on [dbo].[CreditMoneyOperationBrowse] to [public]
go
