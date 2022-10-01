create procedure [dbo].[ReminderGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Reminder';

	select
		[Id],
		[State],
		[FileAs],
		[StartDate],
		[DueDate],
		[ReminderTime],
		[UserId],
		[DocumentTypeId],
		[DocumentId],
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
		[dbo].[Reminder] as [Reminder]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
