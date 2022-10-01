CREATE PROCEDURE [dbo].[DishIngredientCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishIngredientCreateInternal] @xml, @Id out;

	exec [dbo].[DishIngredientGet] @Id;

	return 0;
end
