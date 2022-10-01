CREATE PROCEDURE [dbo].[ProjectTaskStatusReport] @xml xml
as
begin
	set nocount on;

	declare @ProjectManagerId TIdentifier, @PeriodStart date, @PeriodEnd date,
			@OrganizationId TIdentifier, @TradeMarkId TIdentifier;

	select
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@TradeMarkId = T.c.value('TradeMarkId[1]', 'TIdentifier'),
		@ProjectManagerId = T.c.value('ProjectManagerId[1]', 'TIdentifier'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date')
	from
		@xml.nodes('/ProjectTaskStatusReport') as T(c);

	with [ProjectTaskStatusReportItem] ([Id], [TaskNo], [TaskSubject], [TaskState], [ProjectTaskStatusId], [ProjectTaskStatus], [Color], [Complete], [ServiceRequestId], [ServiceRequestNumber], [AccountId], [AccountFileAs], [ProjectManagerId]) as
	(
		select 
			[ProjectTask].[Id],
			[ProjectTask].[TaskNo],
			[ProjectTask].[FileAs] as [TaskSubject],
			[ProjectTask].[State] as [TaskState],
			[ProjectTask].[ProjectTaskStatusId],
			[ProjectTaskStatus].[FileAs],
			[ProjectTaskStatus].[Color],
			(case when [ProjectTask].[State] = 4 then 1 else 0 end) as [Compete],
			[ServiceRequest].[Id] as [ServiceRequestId],
			[ServiceRequest].[Number] as [ServiceRequestNumber],
			[ServiceRequest].[AccountId],
			[Account].[FileAs] as [AccountFileAs],
			[ProjectMember].[EmployeeId]
		from 
			[ProjectTask] inner join [ServiceRequest]
				on ([ProjectTask].[ProjectId] = [ServiceRequest].[ProjectId])
			inner join [Project]	
				on ([ServiceRequest].[ProjectId] = [Project].[Id])
			left outer join [ProjectMember]	
				on ([Project].[Id] = [ProjectMember].[ProjectId] and [ProjectMember].[ProjectMemberRoleId] = 1)
			inner join [dbo].[Account]
				on ([ServiceRequest].[AccountId] = [Account].[Id])
			left outer join [dbo].[ProjectTaskStatus]
				on ([ProjectTask].[ProjectTaskStatusId] = [ProjectTaskStatus].[Id])
		where
			[ProjectTask].[IsMilestone] = 1
		and
			(isnull([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth]) between @PeriodStart and @PeriodEnd)
		and
			([ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @xml.nodes('ProjectTaskStatusReport/State') as T(c)))
		and
			(@ProjectManagerId is null or [ProjectMember].[EmployeeId] = @ProjectManagerId)
		and 
			(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
		and
			(@TradeMarkId is null or [ServiceRequest].[TradeMarkId] = @TradeMarkId)
	)
	select
		[Id],
		[TaskNo], 
		[TaskSubject], 
		[TaskState], 
		[ProjectTaskStatusId], 
		[ProjectTaskStatus], 
		[Color], 
		[Complete], 
		[ServiceRequestId], 
		[ServiceRequestNumber], 
		[AccountId], 
		[AccountFileAs]
	from
		[ProjectTaskStatusReportItem]
	order by
		[AccountFileAs],
		[ServiceRequestId]
	for xml auto, root('Response');

	return 0;
end
