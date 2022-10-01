create procedure [dbo].[PresentationNodeGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'PresentationNode';

	select
		[Id],
		[State],
		[FileAs],
		[Key],
		[DefaultViewId],
		[ViewControlTypeName],
		[OrdinalPosition],
		[Parameter],
		[ParentId],
		[DocumentTypeId],
		[SmallImageData],
		[LargeImageData],
		[NodeType],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[PresentationNodeId], [ApplicationRoleId]
		from
			[PresentationNodeApplicationRole] 
		where
			[PresentationNodeId] = [PresentationNode].[Id] for xml auto, type) as [Roles],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[PresentationNode] as [PresentationNode]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
