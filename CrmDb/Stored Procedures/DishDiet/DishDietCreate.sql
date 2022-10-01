CREATE PROCEDURE [dbo].[DishDietCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishDietCreateInternal] @xml, @Id out;

	exec [dbo].[DishDietGet] @Id;

	return 0;
end
