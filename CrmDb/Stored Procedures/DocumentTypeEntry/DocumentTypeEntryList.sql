create procedure [dbo].[DocumentTypeEntryList] @filter xml
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
		[Id],
		[State],
		[FileAs],
		[ClassName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterMode],
		[IsNumbered],
		[SmallImage],
		[LargeImage],
		[SupportsTransitionTemplates]
	from
		[dbo].[DocumentTypeEntry]
	where
		(@Id is null or [Id] = @Id)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
