create procedure [dbo].[ProductCostStatementDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;
	
	delete [dbo].[ProductCostStatementLine] where [ProductCostStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ProductCostStatement] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
