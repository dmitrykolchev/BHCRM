create procedure [dbo].[ProjectMemberDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProjectMember] where [Id] = @Id;

	return 0;
end
