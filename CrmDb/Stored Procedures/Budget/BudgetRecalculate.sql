CREATE PROCEDURE [dbo].[BudgetRecalculate] @BudgetId TIdentifier
as
begin
	set nocount on;

	delete from [dbo].[BudgetLine] where [BudgetId] = @BudgetId;
	if @@error <> 0
		return 1;

	with [CL] ([BudgetId], [BudgetItemId], [CalculationStage], [Total]) as
	(
		select 
			[C].[BudgetId],
			[C].[IncomeBudgetItemId],
			[C].[CalculationStage],
			sum([L].[Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [L].[Price] * (1.0 - [C].[Discount]))
		from 
			[CalculationStatement] as [C] inner join [CalculationStatementLine] as [L]
				on ([C].[Id] = [L].[CalculationStatementId])
		where
			[C].[IncomeBudgetItemId] is not null and [C].[BudgetId] = @BudgetId
		group by
			[C].[BudgetId],
			[C].[CalculationStage],
			[C].[IncomeBudgetItemId]
		union all
		select 
			[C].[BudgetId],
			[C].[ExpenseBudgetItemId],
			[C].[CalculationStage],
			sum([L].[Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [L].[Cost])
		from 
			[CalculationStatement] as [C] inner join [CalculationStatementLine] as [L]
				on ([C].[Id] = [L].[CalculationStatementId])
		where
			[C].[ExpenseBudgetItemId] is not null and [C].[BudgetId] = @BudgetId
		group by
			[C].[BudgetId],
			[C].[CalculationStage],
			[C].[ExpenseBudgetItemId]
	)
	insert into [dbo].[BudgetLine]
		([BudgetId], [BudgetItemId], [CalculationStage], [Value])
	select
		[CL].[BudgetId],
		[CL].[BudgetItemId],
		[CL].[CalculationStage],
		[CL].[Total]
	from
		[CL];
	if @@error <> 0
		return 1;

	with [CL] ([BudgetId], [BudgetItemGroupId], [CalculationStage], [VAT]) as
	(
		select 
			[C].[BudgetId],
			[BI].[BudgetItemGroupId],
			[C].[CalculationStage],
			sum([L].[Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [L].[Price] * (1.0 - [C].[Discount]) * [V].[Value])
		from 
			[CalculationStatement] as [C] inner join [CalculationStatementLine] as [L]
				on ([C].[Id] = [L].[CalculationStatementId])
			inner join [BudgetItem] as [BI]
				on ([C].[IncomeBudgetItemId] = [BI].[Id])
			inner join [VATRate] as [V]
				on ([C].[VATRateId] = [V].[Id])
		where
			[C].[IncomeBudgetItemId] is not null and [C].[BudgetId] = @BudgetId
		group by
			[C].[BudgetId],
			[C].[CalculationStage],
			[BI].[BudgetItemGroupId]
	)
	insert into [BudgetLine]
		([BudgetId], [BudgetItemId],[CalculationStage],[Value])
	select
		[CL].[BudgetId],
		case when [CL].[BudgetItemGroupId] = 1 then 8 else 31 end,
		[CL].[CalculationStage],
		[CL].[VAT]
	from
		[CL]
	union all
	select
		[CL].[BudgetId],
		case when [CL].[BudgetItemGroupId] = 1 then 24 else 38 end,
		[CL].[CalculationStage],
		[CL].[VAT]
	from
		[CL];
	if @@error <> 0
		return 1;

	with [T] ([Value]) as 
	(
		select 
			sum([BudgetLine].[Value]) 
		from 
			[BudgetLine] inner join [BudgetItem]
				on ([BudgetLine].[BudgetItemId] = [BudgetItem].[Id])
			inner join [Budget]	
				on ([BudgetLine].[BudgetId] = [Budget].[Id])
		where
			[BudgetLine].[BudgetId]=@BudgetId 
		and 
			[BudgetItem].[BudgetItemGroupId] in (1, 3) 
		and 
			[BudgetLine].[CalculationStage] = [Budget].[State]
	)
	update [Budget]
	set
		[Value] = isnull([T].[Value], 0)
	from
		[T]
	where
		[Budget].[Id] = @BudgetId;
	if @@error <> 0
		return 1;

	return 0;
end
