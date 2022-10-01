CREATE TABLE [dbo].[ProjectTask]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[TaskNo] int not null default(0),
	[FileAs] TName not null,
	[ProjectId] TIdentifier not null,
	[ProjectMemberRoleId] TIdentifier null,
	[AssignedToEmployeeId] TIdentifier null,
	[ProjectTaskStatusId] TIdentifier null,
	[ProjectTaskStatus] nvarchar(1024) null,
	[IsMilestone] bit not null default(0),
	[TaskStart] date not null,
	[TaskFinish] date not null,
	[Importance] TIdentifier not null default(2),
	[Complete] decimal(4,2) not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_ProjectTask_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_ProjectTask_AssignedToEmployee] FOREIGN KEY ([AssignedToEmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_ProjectTask_ProjectMemberRole] FOREIGN KEY ([ProjectMemberRoleId]) REFERENCES [ProjectMemberRole]([Id]), 
    CONSTRAINT [FK_ProjectTask_ProjectTaskStatus] FOREIGN KEY ([ProjectTaskStatusId]) REFERENCES [ProjectTaskStatus]([Id])
)

GO

create trigger [dbo].[TriggerProjectTaskInsertUpdate] on [dbo].[ProjectTask] for insert, update
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProjectTask]
	set
		[State] = 4,
		[Complete] = 1,
		[Created] = getdate(),
		[CreatedBy] = @UserId
	from
		[dbo].[ProjectTask] inner join [inserted]	
			on ([ProjectTask].[Id] = [inserted].[Id])
	where
		[inserted].[Complete] >= 1 and [inserted].[State] <> 4;

	if @@error <> 0
	begin
		rollback transaction;
		return;
	end

	update [dbo].[ProjectTask]
	set
		[State] = 2,
		[Created] = getdate(),
		[CreatedBy] = @UserId
	from
		[dbo].[ProjectTask] inner join [inserted]	
			on ([ProjectTask].[Id] = [inserted].[Id])
	where
		[inserted].[Complete] < 1 and [inserted].[State] = 1 and [inserted].[AssignedToEmployeeId] is not null;
	if @@error <> 0
	begin
		rollback transaction;
		return;
	end

	update [dbo].[ProjectTask]
	set
		[State] = 1,
		[Created] = getdate(),
		[CreatedBy] = @UserId
	from
		[dbo].[ProjectTask] inner join [inserted]	
			on ([ProjectTask].[Id] = [inserted].[Id])
	where
		[inserted].[Complete] < 1 and [inserted].[State] = 2 and [inserted].[AssignedToEmployeeId] is null;
	if @@error <> 0
	begin
		rollback transaction;
		return;
	end

	return;
end
go

create trigger [dbo].[ProjectTaskNotificationTriggerInsertUpdate] on [dbo].[ProjectTask] for insert, update
as
begin
    set nocount on;
	declare ProjectTasks cursor local forward_only read_only for 
		select 
			[inserted].[Id], [inserted].[AssignedToEmployeeId], [deleted].[AssignedToEmployeeId] 
		from 
			[inserted] left outer join [deleted] 
				on ([inserted].[Id] = [deleted].[Id])
		where 
			([inserted].[AssignedToEmployeeId] is not null or [deleted].[AssignedToEmployeeId] is not null) 
			and 
			isnull([inserted].[AssignedToEmployeeId], 0) <> isnull([deleted].[AssignedToEmployeeId], 0);
	open ProjectTasks;	

	declare @result int, @ProjectTaskId TIdentifier, @EmployeeId TIdentifier, @RemovedEmployeeId TIdentifier;

	fetch next from ProjectTasks into @ProjectTaskId, @EmployeeId, @RemovedEmployeeId;
	while @@fetch_status = 0
	begin
		if @EmployeeId is not null
		begin
			exec @result = [dbo].[UserNotificationCreateInternal] @EmployeeId, '#ProjectTaskAssigned', null, 'ProjectTask', @ProjectTaskId;
			if @@error <> 0 or @result <> 0
			begin
				rollback transaction;
				close ProjectTasks;
				deallocate ProjectTasks;
				return;
			end
		end
		if @RemovedEmployeeId is not null
		begin
			exec @result = [dbo].[UserNotificationCreateInternal] @RemovedEmployeeId, '#ProjectTaskUnassigned', null, 'ProjectTask', @ProjectTaskId;
			if @@error <> 0 or @result <> 0
			begin
				rollback transaction;
				close ProjectTasks;
				deallocate ProjectTasks;
				return;
			end
		end
		fetch next from ProjectTasks into @ProjectTaskId, @EmployeeId, @RemovedEmployeeId;
	end
	close ProjectTasks;
	deallocate ProjectTasks;
end
go

