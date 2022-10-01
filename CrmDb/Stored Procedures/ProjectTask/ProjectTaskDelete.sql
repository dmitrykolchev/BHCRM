create procedure [dbo].[ProjectTaskDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[ProjectTaskStatusEntry] where [ProjectTaskId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ProjectTask] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
