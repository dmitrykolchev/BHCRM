create procedure [dbo].[CateringTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[CateringType] where [Id] = @Id;

	return 0;
end
