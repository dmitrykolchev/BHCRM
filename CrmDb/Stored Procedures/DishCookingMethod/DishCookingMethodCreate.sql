CREATE PROCEDURE [dbo].[DishCookingMethodCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishCookingMethodCreateInternal] @xml, @Id out;

	exec [dbo].[DishCookingMethodGet] @Id;

	return 0;
end
