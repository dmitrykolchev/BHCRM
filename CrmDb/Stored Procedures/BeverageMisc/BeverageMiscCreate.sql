CREATE PROCEDURE [dbo].[BeverageMiscCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageMiscCreateInternal] @xml, @Id out;

	exec [dbo].[BeverageMiscGet] @Id;

	return 0;
end
