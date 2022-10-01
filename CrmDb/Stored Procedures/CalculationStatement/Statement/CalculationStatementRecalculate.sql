CREATE PROCEDURE [dbo].[CalculationStatementRecalculate] @Id TIdentifier
AS
begin
	set nocount on;
	
	declare @TotalPrice TMoney, @TotalCost TMoney;

	select
		@TotalPrice = sum([Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [Price]),
		@TotalCost = sum([Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [Cost])
	from	
		[CalculationStatementLine]
	where
		[CalculationStatementId] = @Id;
	if @@error <> 0
		return 1;

	if exists(select * from [CalculationStatementTotal] where [CalculationStatementId] = @Id)
	begin
		update [CalculationStatementTotal]
		set
			[TotalCost] = (case when [CalculationStatement].[ExpenseBudgetItemId] is not null then @TotalCost else null end),
			[TotalPrice] = (case when [CalculationStatement].[IncomeBudgetItemId] is not null then @TotalPrice else null end)
		from
			[CalculationStatementTotal] inner join [CalculationStatement]
				on ([CalculationStatementTotal].[CalculationStatementId] = [CalculationStatement].[Id])
		where
			[CalculationStatementId] = @Id;

		if @@error <> 0
			return 1;
	end
	else
	begin
		insert into [CalculationStatementTotal]
			([CalculationStatementId], [TotalCost], [TotalPrice])
		select
			@Id,
			(case when [CalculationStatement].[ExpenseBudgetItemId] is not null then @TotalCost else null end),
			(case when [CalculationStatement].[IncomeBudgetItemId] is not null then @TotalPrice else null end)
		from
			[CalculationStatement] 
		where
			[Id] = @Id;

		if @@error <> 0
			return 1;
	end

	return 0;
end
