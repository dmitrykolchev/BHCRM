CREATE PROCEDURE [dbo].[DishTypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishTypeUpdateInternal] @xml, @Id out;

	exec [dbo].[DishTypeGet] @Id;

	return 0;
end
