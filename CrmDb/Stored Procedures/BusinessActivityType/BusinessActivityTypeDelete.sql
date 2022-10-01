create procedure [dbo].[BusinessActivityTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BusinessActivityType] where [Id] = @Id;

	return 0;
end
