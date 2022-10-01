create procedure [dbo].[ProjectTaskTemplateGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ProjectTaskTemplate';

	select
		[Id],
		[State],
		[TaskNo],
		[FileAs],
		[ProjectTemplateId],
		[ProjectMemberRoleId],
		[IsMilestone],
		[TaskStartOffset],
		[TaskDuration],
		[Importance],
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
		[dbo].[ProjectTaskTemplate] as [ProjectTaskTemplate]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
