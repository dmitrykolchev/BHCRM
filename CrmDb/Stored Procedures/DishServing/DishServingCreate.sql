CREATE PROCEDURE [dbo].[DishServingCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishServingCreateInternal] @xml, @Id out;

	exec [dbo].[DishServingGet] @Id;

	return 0;
end
