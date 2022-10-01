CREATE PROCEDURE [dbo].[BudgetItemGroupCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BudgetItemGroupCreateInternal] @xml, @Id out;

	exec @result = [dbo].[BudgetItemGroupGet] @Id;

	return 0;
end
