create procedure [dbo].[ProjectMemberAdd] @ProjectId TIdentifier, @EmployeeId TIdentifier, @ProjectMemberRoleId TIdentifier
as
begin
	set nocount on;
	
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	declare @EmployeeFileAs TName;
	select @EmployeeFileAs = [FileAs] from [dbo].[Employee] where [Id] = @EmployeeId;

	if exists(select * from [dbo].[ProjectMember] where [ProjectId] = @ProjectId and [ProjectMemberRoleId] = @ProjectMemberRoleId)
	begin
		update [dbo].[ProjectMember]
		set
			[FileAs] = @EmployeeFileAs,
			[EmployeeId] = @EmployeeId,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[ProjectId] = @ProjectId and [ProjectMemberRoleId] = @ProjectMemberRoleId;
		if @@error <> 0
		begin
			return 1;
		end
	end
	else
	begin

		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created],
			[CreatedBy], [Modified], [ModifiedBy])
		values
			(1, @EmployeeFileAs, @ProjectId, @EmployeeId, @ProjectMemberRoleId, getdate(), @UserId, getdate(), @UserId);
		if @@error <> 0
		begin
			return 1;
		end
	end

	update [dbo].[ProjectTask]
	set
		[AssignedToEmployeeId] = @EmployeeId,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[ProjectId] = @ProjectId
	and 
		[ProjectMemberRoleId] = @ProjectMemberRoleId
	and
		[State] in (1, 2);
	if @@error <> 0
	begin
		return 1;
	end

	return 0;
end
