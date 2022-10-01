create procedure [dbo].[UserDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[User] where [Id] = @Id;

	return 0;
end
