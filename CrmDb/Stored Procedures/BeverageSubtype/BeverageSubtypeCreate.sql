CREATE PROCEDURE [dbo].[BeverageSubtypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageSubtypeCreateInternal] @xml, @Id out;

	exec [dbo].[BeverageSubtypeGet] @Id;

	return 0;
end
