CREATE PROCEDURE [dbo].[DishDietUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishDietUpdateInternal] @xml, @Id out;

	exec [dbo].[DishDietGet] @Id;

	return 0;
end
