CREATE TABLE [dbo].[ProjectMember]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[ProjectId] TIdentifier not null,
	[EmployeeId] TIdentifier null,
	[ProjectMemberRoleId] TIdentifier not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_ProjectMember_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_ProjectMember_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_ProjectMember_ProjectMemberRole] FOREIGN KEY ([ProjectMemberRoleId]) REFERENCES [ProjectMemberRole]([Id]), 
    CONSTRAINT [AK_ProjectMember_Role] UNIQUE ([ProjectId], [ProjectMemberRoleId])
)

GO

create trigger [dbo].[ProjectMemberNotificationTriggerInsertUpdate] on [dbo].[ProjectMember] for insert, update
as
begin

    set nocount on;
	declare ProjectMembers cursor local forward_only read_only for 
		select 
			[inserted].[Id], [inserted].[EmployeeId], [deleted].[EmployeeId]
		from 
			[inserted] left outer join [deleted] 
				on ([inserted].[Id] = [deleted].[Id])
		where 
			([inserted].[EmployeeId] is not null or [deleted].[EmployeeId] is not null) 
			and 
			isnull([inserted].[EmployeeId], 0) <> isnull([deleted].[EmployeeId], 0);
	open ProjectMembers;	

	declare @result int, @ProjectMemberId TIdentifier, @EmployeeId TIdentifier, @RemovedEmployeeId TIdentifier;

	fetch next from ProjectMembers into @ProjectMemberId, @EmployeeId, @RemovedEmployeeId;
	while @@fetch_status = 0
	begin
		if @EmployeeId is not null
		begin
			exec @result = [dbo].[UserNotificationCreateInternal] @EmployeeId, '#ProjectMemberAssigned', null, 'ProjectMember', @ProjectMemberId;
			if @@error <> 0 or @result <> 0
			begin
				rollback transaction;
				close ProjectMembers;
				deallocate ProjectMembers;
				return;
			end
		end
		if @RemovedEmployeeId is not null
		begin
			exec @result = [dbo].[UserNotificationCreateInternal] @RemovedEmployeeId, '#ProjectMemberUnassigned', null, 'ProjectMember', @ProjectMemberId;
			if @@error <> 0 or @result <> 0
			begin
				rollback transaction;
				close ProjectMembers;
				deallocate ProjectMembers;
				return;
			end
		end
		fetch next from ProjectMembers into @ProjectMemberId, @EmployeeId, @RemovedEmployeeId;
	end
	close ProjectMembers;
	deallocate ProjectMembers;
end
go
