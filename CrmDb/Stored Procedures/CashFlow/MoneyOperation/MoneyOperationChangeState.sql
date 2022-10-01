create procedure [dbo].[MoneyOperationChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	begin transaction;

	update [dbo].[MoneyOperation]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [State] != @NewState;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	update [dbo].[MoneyOperation]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[ParentId] = @Id and [State] != @NewState;

	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
