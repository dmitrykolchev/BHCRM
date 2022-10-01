CREATE PROCEDURE [dbo].[BeverageTypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageTypeUpdateInternal] @xml, @Id out;

	exec [dbo].[BeverageTypeGet] @Id;

	return 0;
end
