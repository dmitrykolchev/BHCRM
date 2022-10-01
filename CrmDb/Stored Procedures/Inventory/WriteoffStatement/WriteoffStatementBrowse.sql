create procedure [dbo].[WriteoffStatementBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256),
			@PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier, @StoragePlaceId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@StoragePlaceId = T.c.value('StoragePlaceId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if(@PeriodStart is null)
		set @PeriodStart = cast('0001-01-01' as date);

	if(@PeriodEnd is null)
		set @PeriodEnd = cast('9999-12-31' as date);

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[Subject],
		[OrganizationId],
		[StoragePlaceId],
		[TotalCost],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[WriteoffStatement]
	where
		(@Id is null or [Id] = @Id)
		and
		([WriteoffStatement].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [WriteoffStatement].[OrganizationId] = @OrganizationId)
		and
		(@StoragePlaceId is null or [WriteoffStatement].[StoragePlaceId] = @StoragePlaceId)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
