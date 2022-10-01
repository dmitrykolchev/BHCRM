create procedure [dbo].[ProjectMemberRemove] @ProjectId TIdentifier, @EmployeeId TIdentifier
as
begin
	set nocount on;

	declare @ProjectMemberRoleId TIdentifier;


	update [dbo].[ProjectMember]
	set
		[EmployeeId] = null
	where
		[ProjectId] = @ProjectId and [EmployeeId] = @EmployeeId;

	if @@error <> 0
		return 1;
	
	update [dbo].[ProjectTask]
	set
		[AssignedToEmployeeId] = null
	where
		[ProjectId] = @ProjectId and [AssignedToEmployeeId] = @EmployeeId and [State] in (1, 2);

	if @@error <> 0
		return 1;

	return 0;
end
