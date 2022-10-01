CREATE PROCEDURE [dbo].[BudgetItemGroupUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BudgetItemGroupUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[BudgetItemGroupGet] @Id;

	return 0;
end
