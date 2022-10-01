create procedure [dbo].[ProjectTaskTemplateCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
		@TaskNo = T.c.value('@TaskNo', 'int'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectTemplateId = T.c.value('@ProjectTemplateId', 'TIdentifier'),
		@ProjectMemberRoleId = T.c.value('@ProjectMemberRoleId', 'TIdentifier'),
		@IsMilestone = T.c.value('@IsMilestone', 'bit'),
		@TaskStartOffset = T.c.value('@TaskStartOffset', 'int'),
		@TaskDuration = T.c.value('@TaskDuration', 'int'),
		@Importance = T.c.value('@Importance', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ProjectTaskTemplate') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProjectTaskTemplate]
		([State], [TaskNo], [FileAs], [ProjectTemplateId], [ProjectMemberRoleId], [IsMilestone], [TaskStartOffset],
		[TaskDuration], [Importance], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @TaskNo, @FileAs, @ProjectTemplateId, @ProjectMemberRoleId, @IsMilestone, @TaskStartOffset, @TaskDuration,
		@Importance, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
