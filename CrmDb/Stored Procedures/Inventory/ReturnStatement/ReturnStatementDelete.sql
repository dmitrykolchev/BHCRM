create procedure [dbo].[ReturnStatementDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	declare @DocumentTypeId int = [dbo].[GetDocumentTypeId]('ReturnStatement');

	delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ReturnStatement] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
