CREATE PROCEDURE [dbo].[DishServingUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishServingUpdateInternal] @xml, @Id out;

	exec [dbo].[DishServingGet] @Id;

	return 0;
end
