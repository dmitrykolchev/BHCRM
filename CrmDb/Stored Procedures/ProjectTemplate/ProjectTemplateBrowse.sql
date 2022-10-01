create procedure [dbo].[ProjectTemplateBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[ProjectTypeId],
		[Duration],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ProjectTemplate]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
