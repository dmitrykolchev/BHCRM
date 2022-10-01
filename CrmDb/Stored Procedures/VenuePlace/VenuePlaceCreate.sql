CREATE PROCEDURE [dbo].[VenuePlaceCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[VenuePlaceCreateInternal] @xml, @Id out;

	exec [dbo].[VenuePlaceGet] @Id;

	return 0;
end
