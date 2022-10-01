create procedure [dbo].[PurchaseOrderGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'PurchaseOrder';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[StoragePlaceId],
		[SupplierId],
		[PurchaseInvoiceId],
		[TotalCost],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[PurchaseOrderLineId], [PurchaseOrderId], [ProductId], [Amount], [Cost]
		from
			[PurchaseOrderLine]
		where	
			[PurchaseOrderId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[PurchaseOrder] as [PurchaseOrder]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
