create procedure [dbo].[ServiceRequestUpdateInternal] @xml xml, @Id TIdentifier out
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
			@ProjectId TIdentifier,
			@AmountOfGuests int,
			@Value money,
			@Mileage int,
			@EventLocation nvarchar(256),
			@EventMonth date,
			@EventDate date,
			@EventDuration int,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
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
		@ProjectId = T.c.value('@ProjectId', 'TIdentifier'),
		@AmountOfGuests = T.c.value('@AmountOfGuests', 'int'),
		@Value = T.c.value('@Value', 'money'),
		@Mileage = T.c.value('@Mileage', 'int'),
		@EventLocation = T.c.value('@EventLocation', 'nvarchar(256)'),
		@EventMonth = T.c.value('@EventMonth', 'date'),
		@EventDate = T.c.value('@EventDate', 'date'),
		@EventDuration = T.c.value('@EventDuration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ServiceRequest') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	if exists(select * from [dbo].[Project] where [Id] = @ProjectId)
	begin
		update [dbo].[Project]
		set
			[Code] = @Number,
			[FileAs] = @FileAs,
			[OrganizationId] = @OrganizationId,
			[AccountId] = @AccountId,
			[ResponsibleContactId] = @ResponsibleContactId,
			[StartDate] = @DocumentDate,
			[EndDate] = isnull(@EventDate, @EventMonth),
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[Id] = @ProjectId;
		if @@error <> 0
			return 1;
	end

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[ServiceRequestGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'ServiceRequest', @Id, null, @LogData, null;
	if @@error <> 0 or @result <> 0
		return 1;
	-- end log document state entry	

	update [dbo].[ServiceRequest]
	set
		[Number] = @Number,
		[FileAs] = @FileAs,
		[DocumentDate] = @DocumentDate,
		[TradeMarkId] = @TradeMarkId,
		[OrganizationId] = @OrganizationId,
		[AccountId] = @AccountId,
		[CustomerId] = @CustomerId,
		[VenueProviderId] = @VenueProviderId,
		[AgentId] = @AgentId,
		[ResponsibleContactId] = @ResponsibleContactId,
		[ServiceRequestTypeId] = @ServiceRequestTypeId,
		[ServiceLevelId] = @ServiceLevelId,
		[ReasonId] = @ReasonId,
		[LeadSourceId] = @LeadSourceId,
		[ProjectId] = @ProjectId,
		[AmountOfGuests] = @AmountOfGuests,
		[Value] = @Value,
		[Mileage] = @Mileage,
		[EventLocation] = @EventLocation,
		[EventMonth] = @EventMonth,
		[EventDate] = @EventDate,
		[EventDuration] = @EventDuration,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	return 0;
end
