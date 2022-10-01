create procedure [dbo].[DocumentAccessControlListGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'DocumentAccessControlList';

	with [A] ([DocumentTypeId], [ApplicationRoleId], [RightFlags]) as
	(
		select 
			[DocumentType].[Id],
			[ApplicationRole].[Id],
			0xFFFFFFFF
		from	
			[DocumentType] cross join [ApplicationRole]
		where
			[DocumentType].[ClassName] <> 'Virtual'
	),
	[Right] ([DocumentTypeId], [ApplicationRoleId], [RightFlags]) as
	(
		select
			[A].[DocumentTypeId],
			[A].[ApplicationRoleId],
			coalesce([R].[RightFlags],[A].[RightFlags])
		from
			[A] left outer join [DocumentGenericRight] as [R]
				on ([A].[DocumentTypeId] = [R].[DocumentTypeId] and [A].[ApplicationRoleId] = [R].[ApplicationRoleId])
	)
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
		(select
			[DocumentTypeId], [ApplicationRoleId], [RightFlags]
		from
			[Right]
		order by
			[DocumentTypeId], [ApplicationRoleId] for xml auto, type) as [Rights],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[DocumentAccessControlList] as [DocumentAccessControlList]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
