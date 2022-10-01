CREATE PROCEDURE [dbo].[BudgetItemLinkUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BudgetItemLinkUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[BudgetItemLinkGet] @Id;

	return 0;
end
