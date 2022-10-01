create procedure [dbo].[AccrualBrowse] @filter xml
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
	with [SI] ([DocumentDate], [BudgetId], [OperatingBudgetId], [BudgetItemGroupId], [BudgetItemId], [Value]) as
	(
		select
			[DocumentDate],
			[BudgetId],
			[OperatingBudgetId],
			[BudgetItemGroupId],
			[BudgetItemId],
			[Value]
		from
			[SalesInvoice]
		where
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
			[BudgetItemGroupId] in (select [Id] from [BudgetItemGroup] where [BudgetItemGroupType] in (1, 2))
	)
	, [PI] ([DocumentDate], [BudgetId], [OperatingBudgetId], [BudgetItemGroupId], [BudgetItemId], [Value]) as
	(
		select
			[DocumentDate],
			[BudgetId],
			[OperatingBudgetId],
			[BudgetItemGroupId],
			[BudgetItemId],
			[Value]
		from
			[PurchaseInvoice]
		where
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			([State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
			[BudgetItemGroupId] in (select [Id] from [BudgetItemGroup] where [BudgetItemGroupType] in (1, 2))
	)
	,[I] ([ViewGroup], [BudgetItemGroupId], [BudgetItemId], [Value]) as
	(
		select
			1,
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId],
			sum([SI].[Value])
		from
			[SI] inner join [OperatingBudget]
				on ([SI].[OperatingBudgetId] = [OperatingBudget].[Id])
		where
			coalesce([OperatingBudget].[DocumentDate], [SI].[DocumentDate]) between @PeriodStart and @PeriodEnd
		group by
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId]
		union all
		select
			1,
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId],
			sum([SI].[Value])
		from
			[SI] inner join [Budget]
				on ([SI].[BudgetId] = [Budget].[Id])
			inner join [ServiceRequest]
				on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
		where
			coalesce([ServiceRequest].[EventDate], [SI].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and 
			([ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		group by
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId]
		union all
		select
			1,
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId],
			sum([SI].[Value])
		from
			[SI] 
		where
			[SI].[DocumentDate] between @PeriodStart and @PeriodEnd
		and
			[BudgetId] is null and [OperatingBudgetId] is null
		group by
			[SI].[BudgetItemGroupId],
			[SI].[BudgetItemId]
		union all
		select
			2,
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId],
			sum([PI].[Value])
		from
			[PI] inner join [OperatingBudget]
				on ([PI].[OperatingBudgetId] = [OperatingBudget].[Id])
		where
			coalesce([OperatingBudget].[DocumentDate], [PI].[DocumentDate]) between @PeriodStart and @PeriodEnd
		group by
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId]		
		union all
		select
			2,
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId],
			sum([PI].[Value])
		from
			[PI] inner join [Budget]
				on ([PI].[BudgetId] = [Budget].[Id])
			inner join [ServiceRequest]
				on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
		where
			coalesce([ServiceRequest].[EventDate], [PI].[DocumentDate]) between @PeriodStart and @PeriodEnd
		and 
			([ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		group by
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId]		
		union all
		select
			2,
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId],
			sum([PI].[Value])
		from
			[PI] 
		where
			[PI].[DocumentDate] between @PeriodStart and @PeriodEnd
		and
			[BudgetId] is null and [OperatingBudgetId] is null
		group by
			[PI].[BudgetItemGroupId],
			[PI].[BudgetItemId]		
		union all
		select
			3,
			isnull([SalesOrder].[BudgetItemGroupId], 2), -- Расходы по ОВД
			[SalesOrder].[BudgetItemId],
			sum([SalesOrder].[TotalCost])
		from
			[SalesOrder] inner join [Budget]
				on ([SalesOrder].[BudgetId] = [Budget].[Id])
			inner join [ServiceRequest]
				on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
		where
			[ServiceRequest].[EventDate] between @PeriodStart and @PeriodEnd
		and
			(@OrganizationId is null or [SalesOrder].[OrganizationId] = @OrganizationId)
		and 
			([ServiceRequest].[State] is null or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/ServiceRequestState') as T(c)))
		and
			([Budget].[State] is null or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/BudgetState') as T(c)))
		group by
			isnull([SalesOrder].[BudgetItemGroupId], 2), -- Расходы по ОВД
			[SalesOrder].[BudgetItemId]
	)
	select
		[ViewGroup],
		[BudgetItemGroupId],
		[BudgetItemId],
		[Value]
	from
		[I] as [ConsolidatedAccrualLine]
	for xml auto, root('ArrayOfConsolidatedAccrualLine');


	return 0;
end
go

grant execute on [dbo].[AccrualBrowse] to [public];
go