create procedure [dbo].[CalculationStatementTemplateDelete] @Id TIdentifier
as
begin
	set nocount on;

	declare @result int;

	declare @BudgetTemplateId TIdentifier;

	select @BudgetTemplateId = [BudgetTemplateId] from [dbo].[CalculationStatementTemplate] where [Id] = @Id;

	begin transaction;

	exec @result = [dbo].[CalculationStatementTemplateDeleteInternal] @Id;
	if @@error<> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	exec @result = [dbo].[BudgetTemplateRecalculate] @BudgetTemplateId;
	if @@error<> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
