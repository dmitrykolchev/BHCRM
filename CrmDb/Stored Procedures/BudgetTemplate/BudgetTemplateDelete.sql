create procedure [dbo].[BudgetTemplateDelete] @Id TIdentifier
as
begin
	set nocount on;

	declare calculationTemplates cursor local forward_only fast_forward read_only for select [Id] from [CalculationStatementTemplate] where [BudgetTemplateId] = @Id;
	open calculationTemplates;

	begin transaction;
	
	declare @CalculationTemplateId TIdentifier, @result int;

	fetch next from calculationTemplates into @CalculationTemplateId;
	while @@fetch_status = 0
	begin
		exec @result = [dbo].[CalculationStatementTemplateDeleteInternal] @CalculationTemplateId;		
		if @@error <> 0 or @result <> 0
		begin
			close calculations;
			deallocate calculations;
			rollback transaction;
			return 1;
		end
		fetch next from calculationTemplates into @CalculationTemplateId;
	end
	close calculationTemplates;
	deallocate calculationTemplates;

	delete [dbo].[BudgetTemplateLine] where [BudgetTemplateId] = @Id;

	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[BudgetTemplate] where [Id] = @Id;

	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
