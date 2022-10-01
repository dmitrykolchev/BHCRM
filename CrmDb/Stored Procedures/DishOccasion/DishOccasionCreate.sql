CREATE PROCEDURE [dbo].[DishOccasionCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishOccasionCreateInternal] @xml, @Id out;

	exec [dbo].[DishOccasionGet] @Id;

	return 0;
end
