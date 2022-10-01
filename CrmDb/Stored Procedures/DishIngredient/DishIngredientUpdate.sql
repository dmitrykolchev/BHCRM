CREATE PROCEDURE [dbo].[DishIngredientUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishIngredientUpdateInternal] @xml, @Id out;

	exec [dbo].[DishIngredientGet] @Id;

	return 0;
end
