create procedure [dbo].[AccountEventGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'AccountEvent';

	select
		[Id],
		[State],
		[FileAs],
		[AccountEventTypeId],
		[AccountEventDirectionId],
		[Importance],
		[EventStart],
		[EventEnd],
		[AccountId],
		[ContactId],
		[ServiceRequestId],
		[EmployeeId],
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
		[dbo].[AccountEvent] as [AccountEvent]
	where
		[Id] = @Id
	for xml auto, binary base64;

	return 0;
end
