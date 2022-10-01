CREATE PROCEDURE [dbo].[BudgetItemLinkCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BudgetItemLinkCreateInternal] @xml, @Id out;

	exec @result = [dbo].[BudgetItemLinkGet] @Id;

	return 0;
end
