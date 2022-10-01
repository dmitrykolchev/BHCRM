CREATE PROCEDURE [dbo].[CalculationStatementDeleteInternal] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[CalculationStatementTotal] where [CalculationStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[CalculationStatementLine] where [CalculationStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[CalculationStatementSection] where [CalculationStatementId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[CalculationStatement] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	return 0;
end
