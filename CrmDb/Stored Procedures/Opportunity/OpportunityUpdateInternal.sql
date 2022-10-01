create procedure [dbo].[OpportunityUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@OrganizationId TIdentifier,
			@AssignedToEmployeeId TIdentifier,
			@AccountId TIdentifier,
			@OpportunityTypeId TIdentifier,
			@LeadSourceId TIdentifier,
			@ProjectTypeId TIdentifier,
			@ReasonId TIdentifier,
			@AmountOfGuests int,
			@Value money,
			@DateClosed date,
			@EventDate date,
			@Probability decimal(4,2),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'TIdentifier'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@OpportunityTypeId = T.c.value('@OpportunityTypeId', 'TIdentifier'),
		@LeadSourceId = T.c.value('@LeadSourceId', 'TIdentifier'),
		@ProjectTypeId = T.c.value('@ProjectTypeId', 'TIdentifier'),
		@ReasonId = T.c.value('@ReasonId', 'TIdentifier'),
		@AmountOfGuests = T.c.value('@AmountOfGuests', 'int'),
		@Value = T.c.value('@Value', 'money'),
		@DateClosed = T.c.value('@DateClosed', 'date'),
		@EventDate = T.c.value('@EventDate', 'date'),
		@Probability = T.c.value('@Probability', 'decimal(4,2)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Opportunity') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Opportunity]
	set
		[FileAs] = @FileAs,
		[OrganizationId] = @OrganizationId,
		[AssignedToEmployeeId] = @AssignedToEmployeeId,
		[AccountId] = @AccountId,
		[OpportunityTypeId] = @OpportunityTypeId,
		[LeadSourceId] = @LeadSourceId,
		[ProjectTypeId] = @ProjectTypeId,
		[ReasonId] = @ReasonId,
		[AmountOfGuests] = @AmountOfGuests,
		[Value] = @Value,
		[DateClosed] = @DateClosed,
		[EventDate] = @EventDate,
		[Probability] = @Probability,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
