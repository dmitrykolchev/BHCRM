CREATE PROCEDURE [dbo].[DishOccasionUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishOccasionUpdateInternal] @xml, @Id out;

	exec [dbo].[DishOccasionGet] @Id;

	return 0;
end
