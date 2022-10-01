create procedure [dbo].[CurrentUserBrowse] @filter xml
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
		[FirstName],
		[MiddleName],
		[LastName],
		[WindowsIdentity],
		[SqlIdentity],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[CurrentUser]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		[Id] = [dbo].[GetCurrentUserId]();

	return 0;
end
