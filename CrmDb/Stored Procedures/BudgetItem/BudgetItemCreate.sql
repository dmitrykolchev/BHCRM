CREATE PROCEDURE [dbo].[BudgetItemCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BudgetItemCreateInternal] @xml, @Id out;

	exec @result = [dbo].[BudgetItemGet] @Id;

	return 0;
end
