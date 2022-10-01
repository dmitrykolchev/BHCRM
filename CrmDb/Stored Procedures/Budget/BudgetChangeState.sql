create procedure [dbo].[BudgetChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int, @ApprovedState tinyint;

	set @UserId = [dbo].[GetCurrentUserId]();

	select @ApprovedState = [State] from [DocumentState] where [DocumentTypeId] = dbo.GetDocumentTypeId('CalculationStatement') and [Name] = 'Approved'

	if @NewState = 2
	begin
		if exists(select * from [CalculationStatement] where [BudgetId] = @Id and [CalculationStage] = 2 and [State] <> @ApprovedState)
			throw 50489, '#PlannedCalculationsNotApproved', 1;
	end
	else if @NewState = 3
	begin
		if exists(select * from [CalculationStatement] where [BudgetId] = @Id and [CalculationStage] = 3 and [State] <> @ApprovedState)
			throw 50489, '#ActualCalculationsNotApproved', 1;
	end

	begin transaction;

	update [dbo].[Budget]
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
	
	declare @result int;

	exec @result = [dbo].[BudgetRecalculate] @Id
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
