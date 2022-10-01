create procedure [dbo].[ProjectTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProjectType] where [Id] = @Id;

	return 0;
end
