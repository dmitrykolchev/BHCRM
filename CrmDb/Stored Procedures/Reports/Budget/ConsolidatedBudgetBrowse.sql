create procedure [dbo].[ConsolidatedBudgetBrowse] @filter xml
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
	with [CS] ([Id], [DocumentDate], [BudgetId], [CalculationStage], [IncomeBudgetItemId], [ExpenseBudgetItemId], [ServiceRequestId], [TotalCost], [TotalPrice], [VATValue]) as
	(
		select
			[CalculationStatement].[Id],
			[CalculationStatement].[DocumentDate],
			[CalculationStatement].[BudgetId],
			[CalculationStatement].[CalculationStage],
			[CalculationStatement].[IncomeBudgetItemId],
			[CalculationStatement].[ExpenseBudgetItemId],
			[CalculationStatement].[ServiceRequestId],
			[CalculationStatementTotal].[TotalCost],
			[CalculationStatementTotal].[TotalPrice],
			[CalculationStatementTotal].[TotalPrice] * [VATRate].[Value]
		from
			[CalculationStatement] inner join [CalculationStatementTotal]
				on ([CalculationStatement].[Id] = [CalculationStatementTotal].[CalculationStatementId])
			inner join [VATRate]
				on ([CalculationStatement].[VATRateId] = [VATRate].[Id])
	)
	, [TV1] ([BudgetItemId], [StandardValue], [PlannedValue], [ActualValue]) as
	(
		select
			8, -- Доходы по ОВД НДС
			sum(case when [CS].[CalculationStage] = 1 then [CS].[VATValue] else null end),
			sum(case when [CS].[CalculationStage] = 2 then [CS].[VATValue] else null end),
			sum(case when [CS].[CalculationStage] = 3 then [CS].[VATValue] else null end)
		from 
			[CS] inner join [ServiceRequest]
				on ([CS].[ServiceRequestId] = [ServiceRequest].[Id])
			inner join [Budget]
				on ([CS].[BudgetId] = [Budget].[Id])
		where
			[CS].[IncomeBudgetItemId] is not null
		and
			coalesce([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth], [CS].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
		and 
			([ServiceRequest].[State] is null or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		and
			[CS].[IncomeBudgetItemId] in (select [Id] from [BudgetItem] where [BudgetItemGroupId] = 1) -- Доходы по ОВД
	)
	, [TV2] ([BudgetItemId], [StandardValue], [PlannedValue], [ActualValue]) as
	(
		select
			31, -- Дополнительные доходы НДС
			sum(case when [CS].[CalculationStage] = 1 then [CS].[VATValue] else null end),
			sum(case when [CS].[CalculationStage] = 2 then [CS].[VATValue] else null end),
			sum(case when [CS].[CalculationStage] = 3 then [CS].[VATValue] else null end)
		from 
			[CS] inner join [ServiceRequest]
				on ([CS].[ServiceRequestId] = [ServiceRequest].[Id])
			inner join [Budget]
				on ([CS].[BudgetId] = [Budget].[Id])
		where
			[CS].[IncomeBudgetItemId] is not null
		and
			coalesce([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth], [CS].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
		and 
			([ServiceRequest].[State] is null or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		and
			[CS].[IncomeBudgetItemId] in (select [Id] from [BudgetItem] where [BudgetItemGroupId] = 3) -- Дополнительные доходы
	)
	, [B] ([BudgetItemId], [StandardValue], [PlannedValue], [ActualValue]) as 
	(
		select 
			[CS].[IncomeBudgetItemId],
			sum(case when [CS].[CalculationStage] = 1 then [CS].[TotalPrice] else null end),
			sum(case when [CS].[CalculationStage] = 2 then [CS].[TotalPrice] else null end),
			sum(case when [CS].[CalculationStage] = 3 then [CS].[TotalPrice] else null end)
		from 
			[CS] inner join [ServiceRequest]
				on ([CS].[ServiceRequestId] = [ServiceRequest].[Id])
			inner join [Budget]
				on ([CS].[BudgetId] = [Budget].[Id])
		where
			[CS].[IncomeBudgetItemId] is not null
		and
			coalesce([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth], [CS].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
		and 
			([ServiceRequest].[State] is null or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		group by
			[CS].[IncomeBudgetItemId]
		union all
		select 
			[CS].[ExpenseBudgetItemId],
			sum(case when [CS].[CalculationStage] = 1 then [CS].[TotalCost] else null end),
			sum(case when [CS].[CalculationStage] = 2 then [CS].[TotalCost] else null end),
			sum(case when [CS].[CalculationStage] = 3 then [CS].[TotalCost] else null end)
		from 
			[CS] inner join [ServiceRequest]
				on ([CS].[ServiceRequestId] = [ServiceRequest].[Id])
			inner join [Budget]
				on ([CS].[BudgetId] = [Budget].[Id])
		where
			[CS].[ExpenseBudgetItemId] is not null
		and
			coalesce([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth], [CS].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
		and 
			([ServiceRequest].[State] is null or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		group by
			[CS].[ExpenseBudgetItemId]
		union all
		select  8, [StandardValue], [PlannedValue], [ActualValue] from [TV1]
		union all
		select 31, [StandardValue], [PlannedValue], [ActualValue] from [TV2]
		union all
		select 24, [StandardValue], [PlannedValue], [ActualValue] from [TV1]
		union all
		select 38, [StandardValue], [PlannedValue], [ActualValue] from [TV2]
	)
	select
		[BudgetItemId],
		[StandardValue],
		[PlannedValue],
		[ActualValue]
	from
		[B] as [ConsolidatedBudgetLine]
	where
		[StandardValue] is not null or [PlannedValue] is not null or [ActualValue] is not null
	for xml auto, root('ArrayOfConsolidatedBudgetLine');

	return 0;
end
go

grant execute on [dbo].[ConsolidatedBudgetBrowse] to [public];
go