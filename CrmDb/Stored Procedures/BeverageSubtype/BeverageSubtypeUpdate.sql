CREATE PROCEDURE [dbo].[BeverageSubtypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageSubtypeUpdateInternal] @xml, @Id out;

	exec [dbo].[BeverageSubtypeGet] @Id;

	return 0;
end
