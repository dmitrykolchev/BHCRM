create procedure [dbo].[PurchaseOrderDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	declare @DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('PurchaseOrder');

	delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[PurchaseOrderLine] where [PurchaseOrderId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[PurchaseOrder] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
