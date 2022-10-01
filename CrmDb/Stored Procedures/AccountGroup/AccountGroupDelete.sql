create procedure [dbo].[AccountGroupDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AccountGroup] where [Id] = @Id;

	return 0;
end
