create procedure [dbo].[InventoryStatementDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;
	delete [dbo].[InventoryStatementLine] where [InventoryStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[InventoryStatement] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
