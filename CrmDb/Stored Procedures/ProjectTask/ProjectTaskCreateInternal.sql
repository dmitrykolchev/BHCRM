create procedure [dbo].[ProjectTaskCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@TaskNo int,
			@FileAs TName,
			@ProjectId TIdentifier,
			@ProjectMemberRoleId TIdentifier,
			@AssignedToEmployeeId TIdentifier,
			@ProjectTaskStatusId TIdentifier,
			@ProjectTaskStatus nvarchar(1024),
			@IsMilestone bit,
			@UpdateStatus bit,
			@TaskStart date,
			@TaskFinish date,
			@Importance TIdentifier,
			@Complete decimal(4,2),
			@Comments nvarchar(max);
	select
		@TaskNo = T.c.value('@TaskNo', 'int'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectId = T.c.value('@ProjectId', 'TIdentifier'),
		@ProjectMemberRoleId = T.c.value('@ProjectMemberRoleId', 'TIdentifier'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'TIdentifier'),
		@ProjectTaskStatusId = T.c.value('@ProjectTaskStatusId', 'TIdentifier'),
		@ProjectTaskStatus = T.c.value('@ProjectTaskStatus', 'nvarchar(1024)'),
		@IsMilestone = T.c.value('@IsMilestone', 'bit'),
		@UpdateStatus = T.c.value('@UpdateStatus', 'bit'),
		@TaskStart = T.c.value('@TaskStart', 'date'),
		@TaskFinish = T.c.value('@TaskFinish', 'date'),
		@Importance = T.c.value('@Importance', 'TIdentifier'),
		@Complete = T.c.value('@Complete', 'decimal(4,2)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ProjectTask') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int, @State TState;

	set @UserId = [dbo].[GetCurrentUserId]();


	if @AssignedToEmployeeId is not null
		set @State = 2;
	else
		set @State = 1;

	insert into [dbo].[ProjectTask]
		([State], [TaskNo], [FileAs], [ProjectId], [ProjectMemberRoleId], [AssignedToEmployeeId], [ProjectTaskStatusId], [ProjectTaskStatus], [IsMilestone],
		[TaskStart], [TaskFinish], [Importance], [Complete], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(@State, @TaskNo, @FileAs, @ProjectId, @ProjectMemberRoleId, @AssignedToEmployeeId, @ProjectTaskStatusId, @ProjectTaskStatus, @IsMilestone, @TaskStart,
		@TaskFinish, @Importance, @Complete, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	if @UpdateStatus = 1
	begin
		declare @Color int;
		if @ProjectTaskStatusId is not null
			select @Color = [Color] from [ProjectTaskStatus] where [Id] = @ProjectTaskStatusId;
		else
			set @Color = 16777215;

		insert into [dbo].[ProjectTaskStatusEntry]
			([ProjectTaskId], [ProjectTaskStatusId], [ProjectTaskStatus], [Color], [Created], [CreatedBy])
		values
			(@Id, @ProjectTaskStatusId, @ProjectTaskStatus, @Color, getdate(), @UserId);
		if @@error <> 0
			return 1;
		
		select @State = [ProjectTaskState] from [ProjectTaskStatus] where [Id] = @ProjectTaskStatusId;

		update [dbo].[ProjectTask]
		set
			[State] = @State,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[Id] = @Id and [State] <> @State;
		if @@error <> 0
			return 1;
	end

	return 0;
end
