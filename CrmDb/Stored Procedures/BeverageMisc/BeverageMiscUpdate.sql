CREATE PROCEDURE [dbo].[BeverageMiscUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BeverageMiscUpdateInternal] @xml, @Id out;

	exec [dbo].[BeverageMiscGet] @Id;

	return 0;
end
