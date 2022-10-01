create procedure [dbo].[PositionDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Position] where [Id] = @Id;

	return 0;
end
