CREATE PROCEDURE [dbo].[BeveragePackCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeveragePackCreateInternal] @xml, @Id out;

	exec [dbo].[BeveragePackGet] @Id;

	return 0;
end
