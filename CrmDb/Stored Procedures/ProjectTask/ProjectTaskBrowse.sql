create procedure [dbo].[ProjectTaskBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @ProjectId TIdentifier, @EmployeeId TIdentifier, @Presentation varchar(256), @ProjectManagerId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@ProjectId = T.c.value('ProjectId[1]', 'TIdentifier'),
		@EmployeeId = T.c.value('EmployeeId[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from
		@filter.nodes('/Filter') as T(c);

	if @Presentation = 'MyTasks'
		set @EmployeeId = [dbo].[GetCurrentEmployeeId]();
	else if @Presentation = 'MyProjectTasks'
		set @ProjectManagerId = [dbo].[GetCurrentEmployeeId]();

	select
		[ProjectTask].[Id],
		[ProjectTask].[State],
		[ProjectTask].[TaskNo],
		[ProjectTask].[FileAs],
		[ProjectTask].[ProjectId],
		[ServiceRequest].[Number] as [ServiceRequestNumber],
		[ServiceRequest].[AccountId] as [ServiceRequestAccountId],
		[ProjectTask].[ProjectMemberRoleId],
		[ProjectTask].[AssignedToEmployeeId],
		[ProjectTask].[ProjectTaskStatusId],
		[ProjectTask].[ProjectTaskStatus],
		[ProjectTaskStatus].[Color],
		[ProjectTask].[IsMilestone],
		[ProjectTask].[TaskStart],
		[ProjectTask].[TaskFinish],
		[ProjectTask].[Importance],
		[ProjectTask].[Complete],
		[ProjectTask].[Comments],
		[ProjectTask].[Created],
		[ProjectTask].[CreatedBy],
		[ProjectTask].[Modified],
		[ProjectTask].[ModifiedBy],
		[ProjectTask].[RowVersion]
	from
		[dbo].[ProjectTask] left outer join [dbo].[ProjectTaskStatus]
			on ([ProjectTask].[ProjectTaskStatusId] = [ProjectTaskStatus].[Id])
		left outer join [dbo].[ServiceRequest]	
			on ([ProjectTask].[ProjectId] = [ServiceRequest].[ProjectId])
		inner join [dbo].[Project]
			on ([ProjectTask].[ProjectId] = [Project].[Id])
	where
		(@AllStates = 1 or [ProjectTask].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@Id is null or [ProjectTask].[Id] = @Id)
	and
		(@ProjectId is null or [ProjectTask].[ProjectId] = @ProjectId)
	and
		(@EmployeeId is null or [AssignedToEmployeeId] = @EmployeeId)
	and
		(@ProjectManagerId is null or @ProjectManagerId in (select [EmployeeId] from [ProjectMember] where [ProjectId] = [ProjectTask].[ProjectId] and [ProjectMemberRoleId] = 1));

	return 0;
end
