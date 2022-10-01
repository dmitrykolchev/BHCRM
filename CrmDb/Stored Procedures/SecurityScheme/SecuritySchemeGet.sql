create procedure [dbo].[SecuritySchemeGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'SecurityScheme';
	
	select
		[Id],
		[State],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select [Code], [FileAs], [Comments] from [ApplicationRole] order by [Code] for xml auto, type) as [Roles],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[SecurityScheme] as [SecurityScheme]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
