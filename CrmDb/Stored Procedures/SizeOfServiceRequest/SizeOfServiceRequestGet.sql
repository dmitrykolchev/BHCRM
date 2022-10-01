create procedure [dbo].[SizeOfServiceRequestGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ServiceRequest';

	select
		[Id],
		[State],
		[FileAs],
		[MinimumValue],
		[MaximumValue],
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
		[dbo].[SizeOfServiceRequest] as [SizeOfServiceRequest]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
