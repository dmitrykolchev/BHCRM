create procedure [dbo].[BudgetItemLinkDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BudgetItemLink] where [Id] = @Id;

	return 0;
end
