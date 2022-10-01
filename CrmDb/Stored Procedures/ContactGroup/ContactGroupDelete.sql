create procedure [dbo].[ContactGroupDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ContactGroup] where [Id] = @Id;

	return 0;
end
