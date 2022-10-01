CREATE PROCEDURE [dbo].[AdvanceBrowse] @filter xml
AS
begin
	set nocount on;

	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier, @EmployeeId TIdentifier;

	select
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@EmployeeId = T.c.value('EmployeeId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

	with [R] ([Id], [Value]) as
	(
	select
		[D].[ParentId],
		sum([D].[Value])
	from
		[MoneyOperation] as [D] inner join [MoneyOperation] as [M]
			on ([D].[ParentId] = [M].[Id] and [M].[MoneyOperationTypeId] = 4)
	where
		([D].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ReportState') as T(c)))
	group by
		[D].[ParentId]
	),
	[AdvanceItem] ([Id], [State], [FileAs], [Number], [DocumentDate], [OrganizationId], [BankAccountId], [AccountId], [EmployeeId], [Value], [ReportedValue],
	[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion]) as
	(
	select
		[MoneyOperation].[Id],
		[MoneyOperation].[State],
		[MoneyOperation].[FileAs],
		[MoneyOperation].[Number],
		[MoneyOperation].[DocumentDate],
		[MoneyOperation].[OrganizationId],
		[MoneyOperation].[BankAccountId],
		[MoneyOperation].[AccountId],
		[MoneyOperation].[EmployeeId],
		[MoneyOperation].[Value],
		[R].[Value] as [ReportedValue],
		[MoneyOperation].[Comments],
		[MoneyOperation].[Created],
		[MoneyOperation].[CreatedBy],
		[MoneyOperation].[Modified],
		[MoneyOperation].[ModifiedBy],
		[MoneyOperation].[RowVersion]
	from	
		[MoneyOperation] left outer join [R]
			on ([MoneyOperation].[Id] = [R].[Id])
	where
		[MoneyOperation].[MoneyOperationTypeId] = 4
	and
		[MoneyOperation].[DocumentDate] between @PeriodStart and @PeriodEnd
	and
		(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
	and
		(@EmployeeId is null or [MoneyOperation].[EmployeeId] = @EmployeeId)
	and
		([MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	)
	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[BankAccountId],
		[AccountId],
		[EmployeeId],
		[Value],
		[ReportedValue],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[AdvanceItem]
	for xml auto, binary base64, root('ArrayOfAdvanceItem')
	
	return 0;
end
go

grant execute on [dbo].[AdvanceBrowse] to [public]
go

