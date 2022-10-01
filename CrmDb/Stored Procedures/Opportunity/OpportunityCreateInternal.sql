create procedure [dbo].[OpportunityCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Opportunity') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Opportunity]
		([State], [FileAs], [OrganizationId], [AssignedToEmployeeId], [AccountId], [OpportunityTypeId],
		[LeadSourceId], [ProjectTypeId], [ReasonId], [AmountOfGuests], [Value], [DateClosed], [EventDate],
		[Probability], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @OrganizationId, @AssignedToEmployeeId, @AccountId, @OpportunityTypeId, @LeadSourceId,
		@ProjectTypeId, @ReasonId, @AmountOfGuests, @Value, @DateClosed, @EventDate, @Probability,
		@Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
