create procedure [dbo].[LeadDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Lead] where [Id] = @Id;

	return 0;
end
