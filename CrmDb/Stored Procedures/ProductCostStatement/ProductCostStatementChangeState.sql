create procedure [dbo].[ProductCostStatementChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();
	begin transaction

	update [dbo].[ProductCostStatement]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	if @NewState = 2
	begin
		update [Product]
		set
			[StandardCost] = [ProductCostStatementLine].[Cost]
		from
			[Product] inner join [ProductCostStatementLine]
				on ([Product].[Id] = [ProductCostStatementLine].[ProductId] and [ProductCostStatementLine].[ProductCostStatementId] = @Id)
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	commit transaction;

	return 0;
end
