create procedure [dbo].[DocumentTransitionGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'DocumentTransition';

	select
		[Id],
		[State],
		[FileAs],
		[DocumentTypeId],
		[FromState],
		[ToState],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[DocumentTransitionId],
			[ApplicationRoleId]
		from
			[DocumentTransitionAccess] 
		where
			[DocumentTransitionId] = @Id for xml auto, type) as [Roles],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[DocumentTransition] as [DocumentTransition]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
