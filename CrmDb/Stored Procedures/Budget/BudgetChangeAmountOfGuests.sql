CREATE PROCEDURE [dbo].[BudgetChangeAmountOfGuests] @xml xml
AS
begin
	set nocount on;

	declare @OldAmountOfGuests int, @State TState, @BudgetId TIdentifier, @NewAmountOfGuests int;

	select
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@NewAmountOfGuests = T.c.value('@AmountOfGuests', 'int')
	from
		@xml.nodes('/BudgetAmountOfGuests') as T(c);

	if @BudgetId is null or @NewAmountOfGuests is null
		throw 50489, '#ArgumentNullException', 1;

	select @OldAmountOfGuests = [AmountOfGuests], @State = [State] from [Budget] where [Id] = @BudgetId;

	if @NewAmountOfGuests = @OldAmountOfGuests
		return 0;

	declare @CalculationStatementId TIdentifier;

	begin transaction

	update [Budget]
	set
		[State] = 1,
		[AmountOfGuests] = @NewAmountOfGuests
	where
		[Id] = @BudgetId;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	declare calculations cursor local read_only forward_only for
		select [Id] from [CalculationStatement] where [BudgetId] = @BudgetId and [CalculationStage] = 2 and [DependsOnAmountOfPersons] <> 0;
	open calculations;

	fetch next from calculations into @CalculationStatementId;
	while @@fetch_status = 0
	begin
		update [CalculationStatement]
		set
			[State] = 1
		where
			[Id] = @CalculationStatementId;
		if @@error <> 0
		begin
			close calculations;
			deallocate calculations;
			rollback transaction;
			return 1;
		end

		update [CalculationStatementLine]
		set
			[Amount] = [Amount] * @NewAmountOfGuests / @OldAmountOfGuests
		where
			[CalculationStatementId] = @CalculationStatementId;
		if @@error <> 0
		begin
			close calculations;
			deallocate calculations;
			rollback transaction;
			return 1;
		end

		fetch next from calculations into @CalculationStatementId;
	end
	close calculations;
	deallocate calculations;
	
	declare @result int;

	exec @result = [dbo].[BudgetRecalculate] @BudgetId
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
		
	commit transaction;

	return 0;
end
go

grant execute on [dbo].[BudgetChangeAmountOfGuests] to public
go
