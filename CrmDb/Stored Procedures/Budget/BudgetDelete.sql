create procedure [dbo].[BudgetDelete] @Id TIdentifier
as
begin
	set nocount on;

	declare calculations cursor local forward_only fast_forward read_only for select [Id], [CalculationStage] from [CalculationStatement] where [BudgetId] = @Id;
	open calculations;

	begin transaction;
	
	declare @CalculationId TIdentifier, @stage int, @result int;

	fetch next from calculations into @CalculationId, @stage;
	while @@fetch_status = 0
	begin
		if @stage = 1
			exec @result = [dbo].[CalculationStatementDeleteBypassSecurityCheck] @CalculationId;
		else
			exec @result = [dbo].[CalculationStatementDeleteInternal] @CalculationId;		
		if @@error <> 0 or @result <> 0
		begin
			close calculations;
			deallocate calculations;
			rollback transaction;
			return 1;
		end
		fetch next from calculations into @CalculationId, @stage;
	end
	close calculations;
	deallocate calculations;

	delete [dbo].[BudgetLine] where [BudgetId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[Budget] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;
	return 0;
end
