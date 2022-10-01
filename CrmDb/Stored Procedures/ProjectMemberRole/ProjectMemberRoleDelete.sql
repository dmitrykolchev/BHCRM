create procedure [dbo].[ProjectMemberRoleDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProjectMemberRole] where [Id] = @Id;

	return 0;
end
