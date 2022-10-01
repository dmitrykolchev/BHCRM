CREATE PROCEDURE [dbo].[DishSubtypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishSubtypeCreateInternal] @xml, @Id out;

	exec [dbo].[DishSubtypeGet] @Id;

	return 0;
end
