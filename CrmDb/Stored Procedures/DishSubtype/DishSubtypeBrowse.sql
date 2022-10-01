create procedure [dbo].[DishSubtypeBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @DishTypeId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@DishTypeId = T.c.value('DishTypeId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[DishTypeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DishSubtype]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@DishTypeId is null or [DishTypeId] = @DishTypeId);

	return 0;
end
