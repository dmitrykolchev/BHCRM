CREATE PROCEDURE [dbo].[DishCookingMethodUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishCookingMethodUpdateInternal] @xml, @Id out;

	exec [dbo].[DishCookingMethodGet] @Id;

	return 0;
end
