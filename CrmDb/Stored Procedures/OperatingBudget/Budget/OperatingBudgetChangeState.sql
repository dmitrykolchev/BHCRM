create procedure [dbo].[OperatingBudgetChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	begin transaction;

	if @NewState = 1
	begin
		update [dbo].[Payroll]
		set
			[State] = 1,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		update [dbo].[OperatingCalculation]
		set
			[State] = 1,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end
	if @NewState = 2
	begin	
		update [dbo].[Payroll]
		set
			[State] = (case when [CalculationStage] = 2 then 2 else 1 end),
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		update [dbo].[OperatingCalculation]
		set
			[State] = (case when [CalculationStage] = 2 then 2 else 1 end),
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end
	else if @NewState = 3
	begin
		update [dbo].[Payroll]
		set
			[State] = 2,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		update [dbo].[OperatingCalculation]
		set
			[State] = 2,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		where
			[OperatingBudgetId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	update [dbo].[OperatingBudget]
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

	commit transaction;

	return 0;
end
