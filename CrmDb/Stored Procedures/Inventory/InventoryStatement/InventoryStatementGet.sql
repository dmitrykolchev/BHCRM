create procedure [dbo].[InventoryStatementGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'InventoryStatement';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
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
			[InventoryStatementLineId], [InventoryStatementId], [ProductId], [ExpectedAmount], [Amount], [Cost]
		from
			[InventoryStatementLine] where [InventoryStatementId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[InventoryStatement] as [InventoryStatement]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
