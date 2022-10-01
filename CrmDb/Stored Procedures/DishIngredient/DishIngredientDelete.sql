create procedure [dbo].[DishIngredientDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishIngredient] where [Id] = @Id;

	return 0;
end
