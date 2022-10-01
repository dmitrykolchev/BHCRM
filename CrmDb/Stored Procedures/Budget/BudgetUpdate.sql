CREATE PROCEDURE [dbo].[BudgetUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;
	begin transaction;

	exec @result = [dbo].[BudgetUpdateInternal] @xml, @Id out;
	if @result <> 0 or @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	commit transaction;

	exec @result = [dbo].[BudgetGet] @Id;

	return 0;
end
