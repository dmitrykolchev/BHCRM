create procedure [dbo].[ApplicationRoleGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ApplicationRole';

	select
		[Id],
		[State],
		[Code],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select [ApplicationRoleId], [UserId] from [UserApplicationRole] where [ApplicationRoleId] = @Id for xml auto, type) as [Users],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[ApplicationRole] as [ApplicationRole]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
