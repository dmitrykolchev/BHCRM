create procedure [dbo].[VenueDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Account] where [Id] = @Id;

	return 0;
end
