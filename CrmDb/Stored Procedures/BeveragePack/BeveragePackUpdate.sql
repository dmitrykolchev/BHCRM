CREATE PROCEDURE [dbo].[BeveragePackUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeveragePackUpdateInternal] @xml, @Id out;

	exec [dbo].[BeveragePackGet] @Id;

	return 0;
end
