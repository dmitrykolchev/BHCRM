create procedure [dbo].[WriteoffStatementDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	declare @DocumentTypeId int = [dbo].[GetDocumentTypeId]('WriteoffStatement');

	delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[WriteoffStatementLine] where [WriteoffStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[WriteoffStatement] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
