create procedure [dbo].[DocumentAttachmentCreate] @ClassName varchar(256), @DocumentId TIdentifier, @BlobId varchar(1024), @BlobName nvarchar(1024)
as
	set nocount on;
	declare @DocumentTypeId int, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	select @DocumentTypeId = [Id] from [dbo].[DocumentType] where [ClassName] = @ClassName;

	insert into [dbo].[DocumentAttachment]
		([DocumentTypeId], [DocumentId], [BlobId], [BlobName], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(@DocumentTypeId, @DocumentId, @BlobId, @BlobName, getdate(), @UserId, getdate(), @UserId);

	declare @Id int;

	select @Id = scope_identity();

	select
		[Id], [DocumentTypeId], [DocumentId], [BlobId], [BlobName], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion]
	from
		[dbo].[DocumentAttachment]
	where
		[Id] = @Id;

	return 0;
