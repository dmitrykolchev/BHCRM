create procedure [dbo].[ReminderDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Reminder] where [Id] = @Id;

	return 0;
end
