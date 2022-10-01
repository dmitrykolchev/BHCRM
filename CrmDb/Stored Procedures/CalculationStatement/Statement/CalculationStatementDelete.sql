create procedure [dbo].[CalculationStatementDelete] @Id TIdentifier
as
begin
	set nocount on;

	declare	@BudgetId TIdentifier, @CalculationStage int;

	select
		@BudgetId = [BudgetId],
		@CalculationStage = [CalculationStage]
	from
		[CalculationStatement]
	where 
		[Id] = @Id;

	begin transaction;

	declare @result int;
	exec @result = [dbo].[CalculationStatementDeleteInternal] @Id;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	exec @result = [dbo].[BudgetRecalculate] @BudgetId
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
