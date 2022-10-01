create procedure [dbo].[ProjectMemberCreate]
	@FileAs TName,
	@ProjectId TIdentifier,
	@EmployeeId TIdentifier,
	@ProjectMemberRoleId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	begin transaction;

	insert into [dbo].[ProjectMember]
		([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Comments], [Created],
		[CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @ProjectId, @EmployeeId, @ProjectMemberRoleId, @Comments, getdate(), @UserId, getdate(),
		@UserId);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	set @Id = scope_identity();

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
