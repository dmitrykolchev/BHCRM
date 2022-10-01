CREATE PROCEDURE [dbo].[BudgetTemplateUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;
	begin transaction;

	exec @result = [dbo].[BudgetTemplateUpdateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	exec @result = [dbo].[BudgetTemplateRecalculate] @Id;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec @result = [dbo].[BudgetTemplateGet] @Id;

	return 0;
end
