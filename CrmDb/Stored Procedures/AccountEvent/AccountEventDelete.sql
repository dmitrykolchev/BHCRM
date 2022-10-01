create procedure [dbo].[AccountEventDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AccountEvent] where [Id] = @Id;

	return 0;
end
