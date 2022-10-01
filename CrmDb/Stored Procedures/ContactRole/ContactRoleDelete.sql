create procedure [dbo].[ContactRoleDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ContactRole] where [Id] = @Id;

	return 0;
end
