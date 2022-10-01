create procedure [dbo].[DocumentAttachmentBrowse] @ClassName varchar(256), @DocumentId TIdentifier
as
	set nocount on;
	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [dbo].[DocumentType] where [ClassName] = @ClassName;

	select
		[Id],
		[DocumentTypeId],
		[DocumentId],
		[BlobId],
		[BlobName],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy]
	from
		[dbo].[DocumentAttachment]
	where
		[DocumentId] = @DocumentId and [DocumentTypeId] = @DocumentTypeId;

	return 0;

