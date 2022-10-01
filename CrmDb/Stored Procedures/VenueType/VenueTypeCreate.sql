CREATE PROCEDURE [dbo].[VenueTypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[VenueTypeCreateInternal] @xml, @Id out;

	exec [dbo].[VenueTypeGet] @Id;

	return 0;
end
