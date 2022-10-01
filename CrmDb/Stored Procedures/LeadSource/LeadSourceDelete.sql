create procedure [dbo].[LeadSourceDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[LeadSource] where [Id] = @Id;

	return 0;
end
