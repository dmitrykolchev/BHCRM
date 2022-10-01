CREATE PROCEDURE [dbo].[BeverageTypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageTypeCreateInternal] @xml, @Id out;

	exec [dbo].[BeverageTypeGet] @Id;

	return 0;
end
