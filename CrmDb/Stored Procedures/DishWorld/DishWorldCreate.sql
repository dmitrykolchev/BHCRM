CREATE PROCEDURE [dbo].[DishWorldCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishWorldCreateInternal] @xml, @Id out;

	exec [dbo].[DishWorldGet] @Id;

	return 0;
end
