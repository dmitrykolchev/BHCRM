create procedure [dbo].[CurrentUserDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[CurrentUser] where [Id] = @Id;

	return 0;
end
