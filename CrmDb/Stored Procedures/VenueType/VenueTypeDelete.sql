create procedure [dbo].[VenueTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[VenueType] where [Id] = @Id;

	return 0;
end
