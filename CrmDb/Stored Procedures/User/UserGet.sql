create procedure [dbo].[UserGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'User';

	select
		[Id],
		[State],
		[FileAs],
		[FirstName],
		[MiddleName],
		[LastName],
		[WindowsIdentity],
		[SqlIdentity],
		[UserName],
		[PasswordHash],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select [UserId], [ApplicationRoleId] from [UserApplicationRole] where [UserId] = @Id for xml auto, type) as [Roles],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[User] as [User]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
