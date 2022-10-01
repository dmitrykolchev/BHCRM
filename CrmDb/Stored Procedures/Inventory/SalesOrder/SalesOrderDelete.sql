create procedure [dbo].[SalesOrderDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	declare @DocumentTypeId int = [dbo].[GetDocumentTypeId]('SalesOrder');

	delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[SalesOrderLine] where [SalesOrderId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[SalesOrder] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
