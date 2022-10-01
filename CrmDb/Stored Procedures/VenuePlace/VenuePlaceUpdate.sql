CREATE PROCEDURE [dbo].[VenuePlaceUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[VenuePlaceUpdateInternal] @xml, @Id out;

	exec [dbo].[VenuePlaceGet] @Id;

	return 0;
end
