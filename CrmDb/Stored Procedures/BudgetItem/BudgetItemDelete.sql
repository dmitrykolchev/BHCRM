create procedure [dbo].[BudgetItemDelete] @Id TIdentifier
as
begin
	set nocount on;
	begin transaction;

	delete [dbo].[BudgetItemProductCategory] where [BudgetItemId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[BudgetItem] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;
	return 0;
end
