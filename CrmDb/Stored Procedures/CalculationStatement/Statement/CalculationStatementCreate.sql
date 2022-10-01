CREATE PROCEDURE [dbo].[CalculationStatementCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[CalculationStatementCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	declare	@BudgetId TIdentifier;

	select
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier')
	from
		@xml.nodes('CalculationStatement') as T(c);

	exec @result = [dbo].[BudgetRecalculate] @BudgetId
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[CalculationStatementGet] @Id;

	return 0;
end
