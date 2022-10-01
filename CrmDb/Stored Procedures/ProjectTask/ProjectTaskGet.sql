create procedure [dbo].[ProjectTaskGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ProjectTask';

	select
		[Id],
		[State],
		[TaskNo],
		[FileAs],
		[ProjectId],
		[ProjectMemberRoleId],
		[AssignedToEmployeeId],
		[ProjectTaskStatusId],
		[ProjectTaskStatus],
		(select [Color] from [ProjectTaskStatus] where [Id] = [ProjectTaskStatusId]) as [Color],
		[IsMilestone],
		[TaskStart],
		[TaskFinish],
		[Importance],
		[Complete],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select * from [dbo].[ProjectTaskStatusEntry] as [ProjectTaskStatusEntry] where [ProjectTaskId] = @Id order by [Id] for xml auto, type) as [Statuses],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[ProjectTask] as [ProjectTask]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
