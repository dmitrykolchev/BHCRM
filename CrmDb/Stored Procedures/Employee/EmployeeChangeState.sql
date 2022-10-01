create procedure [dbo].[EmployeeChangeState] @Id TIdentifier, @NewState TState
as
begin
	declare @EmployeeAccountId TIdentifier;

	set nocount on;
	
	begin transaction;

	update [dbo].[Employee]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = [dbo].[GetCurrentUserId](),
		@EmployeeAccountId = [EmployeeAccountId]
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	update [dbo].[Account]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = [dbo].[GetCurrentUserId]()
	where
		[Id] = @EmployeeAccountId;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end
	
	commit transaction;

	return 0;
end
