create procedure [dbo].[WriteoffStatementGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'WriteoffStatement';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[Subject],
		[OrganizationId],
		[StoragePlaceId],
		[TotalCost],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[WriteoffStatementLineId], [WriteoffStatementId], [ProductId], [Amount], [Cost]
		from
			[WriteoffStatementLine] 
		where	
			[WriteoffStatementId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[WriteoffStatement] as [WriteoffStatement]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
