create procedure [dbo].[ServiceRequestCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Number TCode,
			@FileAs TName,
			@DocumentDate date,
			@TradeMarkId TIdentifier,
			@OrganizationId TIdentifier,
			@AccountId TIdentifier,
			@CustomerId TIdentifier,
			@VenueProviderId TIdentifier,
			@AgentId TIdentifier,
			@ResponsibleContactId TIdentifier,
			@ServiceRequestTypeId TIdentifier,
			@ServiceLevelId TIdentifier,
			@ReasonId TIdentifier,
			@LeadSourceId TIdentifier,
			@AmountOfGuests int,
			@Value money,
			@Mileage int,
			@EventLocation nvarchar(256),
			@EventMonth date,
			@EventDate date,
			@EventDuration int,
			@Comments nvarchar(max);
	select
		@Number = T.c.value('@Number', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@TradeMarkId = T.c.value('@TradeMarkId', 'TIdentifier'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@CustomerId = T.c.value('@CustomerId', 'TIdentifier'),
		@VenueProviderId = T.c.value('@VenueProviderId', 'TIdentifier'),
		@AgentId = T.c.value('@AgentId', 'TIdentifier'),
		@ResponsibleContactId = T.c.value('@ResponsibleContactId', 'TIdentifier'), 
		@ServiceRequestTypeId = T.c.value('@ServiceRequestTypeId', 'TIdentifier'),
		@ServiceLevelId = T.c.value('@ServiceLevelId', 'TIdentifier'),
		@ReasonId = T.c.value('@ReasonId', 'TIdentifier'),
		@LeadSourceId = T.c.value('@LeadSourceId', 'TIdentifier'),
		@AmountOfGuests = T.c.value('@AmountOfGuests', 'int'),
		@Value = T.c.value('@Value', 'money'),
		@Mileage = T.c.value('@Mileage', 'int'),
		@EventLocation = T.c.value('@EventLocation', 'nvarchar(256)'),
		@EventMonth = T.c.value('@EventMonth', 'date'),
		@EventDate = T.c.value('@EventDate', 'date'),
		@EventDuration = T.c.value('@EventDuration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ServiceRequest') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int, @ProjectId TIdentifier;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Project]
		([State], [Code], [FileAs], [ProjectTypeId], [OrganizationId], [AccountId], [ResponsibleContactId], [StartDate], [EndDate], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @Number, @FileAs, 2, @OrganizationId, @AccountId, @ResponsibleContactId, @DocumentDate, isnull(@EventDate, @EventMonth) , getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @ProjectId = scope_identity();

	-- Руководитель проекта

	declare @EmployeeFileAs TName, @ResponsibleEmployeeId TIdentifier;

	set @ResponsibleEmployeeId = [dbo].[GetCurrentEmployeeId]();
	
	select @EmployeeFileAs = [FileAs]  from [dbo].[Employee] where [Id] = @ResponsibleEmployeeId;

	insert into [dbo].[ProjectMember]
		([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @EmployeeFileAs, @ProjectId, @ResponsibleEmployeeId, 1, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;
	
	-- Отвественный за поиск
	
	insert into [dbo].[ProjectMember]
		([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @EmployeeFileAs, @ProjectId, @ResponsibleEmployeeId, 5, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;

	-- Ответственный за продажу

	declare @EmployeeId TIdentifier;

	select @EmployeeId = [AssignedToEmployeeId] from [Account] where [Id] = @AccountId;

	if @EmployeeId is not null
	begin
		select @EmployeeFileAs = [FileAs]  from [dbo].[Employee] where [Id] = @EmployeeId;

		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			(1, @EmployeeFileAs, @ProjectId, @EmployeeId, 2, getdate(), @UserId, getdate(), @UserId);
		if @@error <> 0
			return 1;

		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			1, [FileAs], @ProjectId, null, [Id], getdate(), @UserId, getdate(), @UserId
		from
			[ProjectMemberRole]
		where
			[Id] not in (1, 2, 5);
		if @@error <> 0
			return 1;
	end
	else
	begin
		-- нет ответственного за продажу
		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			1, [FileAs], @ProjectId, null, [Id], getdate(), @UserId, getdate(), @UserId
		from
			[ProjectMemberRole]
		where
			[Id] not in (1, 5);
		if @@error <> 0
			return 1;
	end

	declare @ProjectTemplateId TIdentifier;

	select @ProjectTemplateId = [ProjectTemplateId] from [dbo].[Organization] where [Id] = @OrganizationId;

	if @ProjectTemplateId is not null
	begin
		insert into [dbo].[ProjectTask]
			([State], [TaskNo], [FileAs], [ProjectId], [ProjectMemberRoleId], [AssignedToEmployeeId], [IsMilestone], [TaskStart], [TaskFinish], [Importance], [Complete], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			(select (case when [EmployeeId] is null then 1 else 2 end) from [ProjectMember] where [ProjectMemberRoleId] = [ProjectTaskTemplate].[ProjectMemberRoleId] and [ProjectId] = @ProjectId),
			[TaskNo],
			[FileAs],
			@ProjectId,
			[ProjectMemberRoleId],
			(select [EmployeeId] from [ProjectMember] where [ProjectMemberRoleId] = [ProjectTaskTemplate].[ProjectMemberRoleId] and [ProjectId] = @ProjectId),
			[IsMilestone],
			dateadd(day, [TaskStartOffset], @DocumentDate),
			dateadd(day, [TaskStartOffset] + [TaskDuration], @DocumentDate),
			[Importance],
			0,
			[Comments],
			getdate(), 
			@UserId, 
			getdate(), 
			@UserId
		from
			[dbo].[ProjectTaskTemplate]
		where
			[ProjectTemplateId] = @ProjectTemplateId;
		if @@error <> 0
			return 1;
	end

	insert into [dbo].[ServiceRequest]
		([State], [Number], [FileAs], [DocumentDate], [TradeMarkId], [OrganizationId],
		[AccountId], [CustomerId], [VenueProviderId], [AgentId], [ResponsibleContactId],
		[ServiceRequestTypeId], [ServiceLevelId], [ReasonId], [LeadSourceId], [AmountOfGuests], [Value],
		[Mileage], [EventLocation], [EventMonth], [EventDate], [EventDuration],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [ProjectId])
	values
		(1, @Number, @FileAs, @DocumentDate, @TradeMarkId, @OrganizationId,
		@AccountId, @CustomerId, @VenueProviderId, @AgentId, @ResponsibleContactId, @ServiceRequestTypeId, @ServiceLevelId,
		@ReasonId, @LeadSourceId, @AmountOfGuests, @Value, @Mileage, @EventLocation, @EventMonth,
		@EventDate, @EventDuration, @Comments, getdate(), @UserId, getdate(), @UserId, @ProjectId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	return 0;
end
