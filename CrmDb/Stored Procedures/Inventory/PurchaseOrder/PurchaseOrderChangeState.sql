create procedure [dbo].[PurchaseOrderChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @result int;

	begin transaction;

	exec @result = [dbo].[PurchaseOrderChangeStateInternal] @Id, @NewState;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;
	return 0;
end
