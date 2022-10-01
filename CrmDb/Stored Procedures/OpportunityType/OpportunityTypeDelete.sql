create procedure [dbo].[OpportunityTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[OpportunityType] where [Id] = @Id;

	return 0;
end
