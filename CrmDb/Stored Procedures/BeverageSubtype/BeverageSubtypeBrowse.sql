create procedure [dbo].[BeverageSubtypeBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @BeverageTypeId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@BeverageTypeId = T.c.value('BeverageTypeId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[BeverageTypeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[BeverageSubtype]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@BeverageTypeId is null or [BeverageTypeId] = @BeverageTypeId);

	return 0;
end
