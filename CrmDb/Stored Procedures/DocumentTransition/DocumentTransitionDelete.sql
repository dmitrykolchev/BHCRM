create procedure [dbo].[DocumentTransitionDelete] @Id TIdentifier
as
begin
	set nocount on;
	begin transaction;
	delete [dbo].[DocumentTransitionAccess] where [DocumentTransitionId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	delete [dbo].[DocumentTransition] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	commit transaction;
	return 0;
end
