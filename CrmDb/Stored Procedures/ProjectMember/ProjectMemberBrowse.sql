create procedure [dbo].[ProjectMemberBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @ProjectId TIdentifier, @Id TIdentifier;

	select
		@Id =T.c.value('Id[1]', 'TIdentifier'),
		@ProjectId = T.c.value('ProjectId[1]', 'TIdentifier'),
		@AllStates = T.c.value('AllStates[1]', 'bit')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[ProjectId],
		[EmployeeId],
		[ProjectMemberRoleId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ProjectMember]
	where
		(@Id is null or [Id] = @Id)
	and
		(@ProjectId is null or [ProjectId] = @ProjectId)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
