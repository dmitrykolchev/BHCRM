CREATE PROCEDURE [dbo].[VenueTypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[VenueTypeUpdateInternal] @xml, @Id out;

	exec [dbo].[VenueTypeGet] @Id;

	return 0;
end
