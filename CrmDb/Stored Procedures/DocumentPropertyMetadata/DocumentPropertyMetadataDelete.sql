create procedure [dbo].[DocumentPropertyMetadataDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentPropertyMetadata] where [Id] = @Id;

	return 0;
end
