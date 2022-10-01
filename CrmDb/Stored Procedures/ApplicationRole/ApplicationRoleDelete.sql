create procedure [dbo].[ApplicationRoleDelete] @Id TIdentifier
as
begin
	set nocount on;
	begin transaction

	delete [dbo].[UserApplicationRole] where [ApplicationRoleId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ApplicationRole] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
