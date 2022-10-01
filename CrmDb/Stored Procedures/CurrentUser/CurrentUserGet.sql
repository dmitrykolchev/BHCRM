create procedure [dbo].[CurrentUserGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	set @Id = dbo.GetCurrentUserId();

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'CurrentUser';
	if @Id = 1
	begin
		select
			[Id],
			[State],
			[FileAs],
			[FirstName],
			[MiddleName],
			[LastName],
			[WindowsIdentity],
			[SqlIdentity],
			[Comments],
			[Created],
			[CreatedBy],
			[Modified],
			[ModifiedBy],
			[RowVersion],
			(select @Id as [UserId], [UserApplicationRole].[Id] as [ApplicationRoleId] from [ApplicationRole] as  [UserApplicationRole] for xml auto, type) as [Roles],
			(select @Id as [UserId], [UserAccessRight].[Id] as [AccessRightId] from [AccessRight] as [UserAccessRight] for xml auto, type) as [Rights],
			(select
				[Id], [BlobId], [BlobName] as [Name]
			from
				[DocumentAttachment] as [AttachmentItem]
			where
				[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
		from
			[dbo].[CurrentUser] as [CurrentUser]
		where
			[Id] = 1
		for xml auto, binary base64;
	end
	else
	begin
		with [UserAccessRight] ([UserId], [AccessRightId]) as 
		(
			select distinct
				[UR].[UserId],
				[AR].[AccessRightId]
			from
				[UserApplicationRole] as [UR] inner join [ApplicationRoleAccessRight] as [AR]
					on ([UR].[ApplicationRoleId] = [AR].[ApplicationRoleId])
			where
				[UR].[UserId] = @Id
		)
		select
			[Id],
			[State],
			[FileAs],
			[FirstName],
			[MiddleName],
			[LastName],
			[WindowsIdentity],
			[SqlIdentity],
			[Comments],
			[Created],
			[CreatedBy],
			[Modified],
			[ModifiedBy],
			[RowVersion],
			(select [UserId], [ApplicationRoleId] from [UserApplicationRole] where [UserId] = @Id for xml auto, type) as [Roles],
			(select [UserId], [AccessRightId] from [UserAccessRight] where [UserId] = @Id for xml auto, type) as [Rights],
			(select
				[Id], [BlobId], [BlobName] as [Name]
			from
				[DocumentAttachment] as [AttachmentItem]
			where
				[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
		from
			[dbo].[CurrentUser] as [CurrentUser]
		where
			[Id] = @Id
		for xml auto, binary base64;
	end
	return 0;
end
