create procedure [dbo].[UserNotificationDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[UserNotification] where [Id] = @Id and [UserId] = [dbo].[GetCurrentUserId]();
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
