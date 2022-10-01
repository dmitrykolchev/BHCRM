CREATE PROCEDURE [dbo].[DishTypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishTypeCreateInternal] @xml, @Id out;

	exec [dbo].[DishTypeGet] @Id;

	return 0;
end
