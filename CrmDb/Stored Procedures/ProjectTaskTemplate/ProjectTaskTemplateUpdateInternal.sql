create procedure [dbo].[ProjectTaskTemplateUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@TaskNo int,
			@FileAs TName,
			@ProjectTemplateId TIdentifier,
			@ProjectMemberRoleId TIdentifier,
			@IsMilestone bit,
			@TaskStartOffset int,
			@TaskDuration int,
			@Importance TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@TaskNo = T.c.value('@TaskNo', 'int'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectTemplateId = T.c.value('@ProjectTemplateId', 'TIdentifier'),
		@ProjectMemberRoleId = T.c.value('@ProjectMemberRoleId', 'TIdentifier'),
		@IsMilestone = T.c.value('@IsMilestone', 'bit'),
		@TaskStartOffset = T.c.value('@TaskStartOffset', 'int'),
		@TaskDuration = T.c.value('@TaskDuration', 'int'),
		@Importance = T.c.value('@Importance', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ProjectTaskTemplate') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProjectTaskTemplate]
	set
		[TaskNo] = @TaskNo,
		[FileAs] = @FileAs,
		[ProjectTemplateId] = @ProjectTemplateId,
		[ProjectMemberRoleId] = @ProjectMemberRoleId,
		[IsMilestone] = @IsMilestone,
		[TaskStartOffset] = @TaskStartOffset,
		[TaskDuration] = @TaskDuration,
		[Importance] = @Importance,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
