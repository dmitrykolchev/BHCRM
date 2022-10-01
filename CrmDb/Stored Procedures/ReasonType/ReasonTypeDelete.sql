create procedure [dbo].[ReasonTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ReasonType] where [Id] = @Id;

	return 0;
end
