create function [dbo].[ServiceRequestGetFn](@Id TIdentifier)
returns xml
as
begin
	declare @DocumentTypeId int;

	select @DocumentTypeId = [dbo].[GetDocumentTypeId]('ServiceRequest');

	return (select
		[Id],
		[State],
		[Number],
		[FileAs],
		[DocumentDate],
		[TradeMarkId],
		[OrganizationId],
		[AccountId],
		[CustomerId],
		[VenueProviderId],
		[AgentId],
		[ResponsibleContactId],
		[ServiceRequestTypeId],
		[ServiceLevelId],
		(select [Id] from [EstimatesDocument] where [ServiceRequestId] = @Id) as [EstimatesDocumentId],
		[ReasonId],
		[LeadSourceId],
		[ProjectId],
		[AmountOfGuests],
		[Value],
		[Mileage],
		[EventLocation],
		[EventMonth],
		[EventDate],
		[EventDuration],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[ServiceRequest] as [ServiceRequest]
	where
		[Id] = @Id
		for xml auto, binary base64);
end
