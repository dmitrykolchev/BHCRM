create procedure [dbo].[OpportunityGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Opportunity';

	select
		[Id],
		[State],
		[FileAs],
		[OrganizationId],
		[AssignedToEmployeeId],
		[AccountId],
		[OpportunityTypeId],
		[LeadSourceId],
		[ProjectTypeId],
		[ReasonId],
		[AmountOfGuests],
		[Value],
		[DateClosed],
		[EventDate],
		[Probability],
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
		[dbo].[Opportunity] as [Opportunity]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
