create procedure [dbo].[AccountEventTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AccountEventType] where [Id] = @Id;

	return 0;
end
