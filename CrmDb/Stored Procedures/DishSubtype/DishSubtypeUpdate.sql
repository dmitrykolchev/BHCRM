CREATE PROCEDURE [dbo].[DishSubtypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishSubtypeUpdateInternal] @xml, @Id out;

	exec [dbo].[DishSubtypeGet] @Id;

	return 0;
end
