create procedure [dbo].[OpportunityDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Opportunity] where [Id] = @Id;

	return 0;
end
