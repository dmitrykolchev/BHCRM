create procedure [dbo].[ConsolidatedOperatingBudgetBrowse] @filter xml
as
begin
	set nocount on;
	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier;

	select
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

	with [B] ([BudgetItemId], [PlannedValue], [ActualValue]) as 
	(
		select
			[OperatingBudgetLine].[BudgetItemId],
			sum(case when [OperatingBudgetLine].[CalculationStage] = 2 then [OperatingBudgetLine].[Amount] * [OperatingBudgetLine].[Price] else null end),
			sum(case when [OperatingBudgetLine].[CalculationStage] = 3 then [OperatingBudgetLine].[Amount] * [OperatingBudgetLine].[Price] else null end)
		from
			[OperatingBudgetLine] inner join [OperatingBudget]
				on ([OperatingBudgetLine].[OperatingBudgetId] = [OperatingBudget].[Id])
		where
			[OperatingBudget].[DocumentDate] between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [OperatingBudget].[OrganizationId] = @OrganizationId)
		group by
			[OperatingBudgetLine].[BudgetItemId]
	)
	select
		[BudgetItemId],
		[PlannedValue],
		[ActualValue]
	from
		[B] as [ConsolidatedOperatingBudgetLine]
	where
		[PlannedValue] is not null or [ActualValue] is not null
	for xml raw('ConsolidatedOperatingBudgetLine'), root('ArrayOfConsolidatedOperatingBudgetLine');

	return 0;
end
go

grant execute on [dbo].[ConsolidatedOperatingBudgetBrowse] to [public];
go