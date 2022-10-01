CREATE PROCEDURE [dbo].[BudgetTemplateRecalculate] @BudgetTemplateId TIdentifier
as
begin
	set nocount on;

	update [BudgetTemplateLine]
	set
		[StandardValue] = null
	where
		[BudgetTemplateId] = @BudgetTemplateId;

	with [CL] ([BudgetTemplateId], [BudgetItemId], [Total]) as
	(
		select 
			[C].[BudgetTemplateId],
			[C].[IncomeBudgetItemId],
			sum([L].[Duration] * [L].[Amount] * [L].[Price]) as [Value]
		from 
			[CalculationStatementTemplate] as [C] inner join [CalculationStatementTemplateLine] as [L]
				on ([C].[Id] = [L].[CalculationStatementTemplateId])
		where
			[C].[IncomeBudgetItemId] is not null and [C].[BudgetTemplateId] = @BudgetTemplateId
		group by
			[C].[BudgetTemplateId],
			[C].[IncomeBudgetItemId]
		union all
		select 
			[C].[BudgetTemplateId],
			[C].[ExpenseBudgetItemId],
			sum([L].[Duration] * [L].[Amount] * [L].[Cost]) as [Value]
		from 
			[CalculationStatementTemplate] as [C] inner join [CalculationStatementTemplateLine] as [L]
				on ([C].[Id] = [L].[CalculationStatementTemplateId])
		where
			[C].[ExpenseBudgetItemId] is not null and [C].[BudgetTemplateId] = @BudgetTemplateId
		group by
			[C].[BudgetTemplateId],
			[C].[ExpenseBudgetItemId]
	)
	update [BudgetTemplateLine]
	set
		[StandardValue] = [CL].[Total]
	from
		[BudgetTemplateLine] as [L] inner join [CL]
			on ([L].[BudgetTemplateId] = [CL].[BudgetTemplateId] and [L].[BudgetItemId] = [CL].[BudgetItemId])
	where
		[L].[BudgetTemplateId] = @BudgetTemplateId;
	if @@error <> 0
		return 1;

	return 0;
end
