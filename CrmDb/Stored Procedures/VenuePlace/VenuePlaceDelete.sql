create procedure [dbo].[VenuePlaceDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[VenuePlace] where [Id] = @Id;

	return 0;
end
