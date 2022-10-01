create procedure [dbo].[BudgetItemGroupDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BudgetItemGroup] where [Id] = @Id;

	return 0;
end
