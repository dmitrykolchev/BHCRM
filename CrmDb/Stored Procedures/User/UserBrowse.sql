create procedure [dbo].[UserBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @ApplicationRoleId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@ApplicationRoleId = T.c.value('ApplicationRoleId[1]', 'int')
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
		[UserName],
		[PasswordHash],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[User]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@ApplicationRoleId is null or [Id] in (select [UserId] from [UserApplicationRole] where [ApplicationRoleId] = @ApplicationRoleId));
	return 0;
end
