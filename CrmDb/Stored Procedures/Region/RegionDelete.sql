create procedure [dbo].[RegionDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Region] where [Id] = @Id;

	return 0;
end
