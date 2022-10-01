create procedure [dbo].[ProjectMemberUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@ProjectId TIdentifier,
	@EmployeeId TIdentifier,
	@ProjectMemberRoleId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();
	
	begin transaction;

	update [dbo].[ProjectMember]
	set
		[FileAs] = @FileAs,
		[ProjectId] = @ProjectId,
		[EmployeeId] = @EmployeeId,
		[ProjectMemberRoleId] = @ProjectMemberRoleId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
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
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[ProjectMemberGet] @Id;

	return 0;
end
