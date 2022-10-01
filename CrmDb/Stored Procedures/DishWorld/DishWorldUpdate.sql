CREATE PROCEDURE [dbo].[DishWorldUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishWorldUpdateInternal] @xml, @Id out;

	exec [dbo].[DishWorldGet] @Id;

	return 0;
end
