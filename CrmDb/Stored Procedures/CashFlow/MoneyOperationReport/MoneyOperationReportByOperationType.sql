create procedure [dbo].[MoneyOperationReportByOperationType] @filter xml
as
begin
	set nocount on;

	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier, @BankAccountId TIdentifier;

	select
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@BankAccountId =  T.c.value('BankAccountId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

	select 
		1 as [ViewGroup],
		null as [MoneyOperationTypeId],
		null as [BudgetItemGroupId],
		null as [BudgetItemId],
		sum(case when [MoneyOperation].[MoneyOperationDirection] > 0 then [MoneyOperation].[Value] else 0 end) as [Income],
		sum(case when [MoneyOperation].[MoneyOperationDirection] < 0 then [MoneyOperation].[Value] else 0 end) as [Expense]
	from 
		[MoneyOperation] left outer join [MoneyOperation] as [P]
			on ([MoneyOperation].[ParentId] = [P].[Id])
	where
		[MoneyOperation].[DocumentDate] <= @PeriodStart
	and
		(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
	and
		(@BankAccountId is null or [MoneyOperation].[BankAccountId] = @BankAccountId)
	and
		[MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c))
	and
		([MoneyOperation].[ParentId] is null or [P].[MoneyOperationTypeId] <> 4 or [MoneyOperation].[MoneyOperationTypeId] = 8)
	union all
	select 
		2,
		[MoneyOperation].[MoneyOperationTypeId],
		[MoneyOperation].[BudgetItemGroupId],
		[MoneyOperation].[BudgetItemId],
		sum(case when [MoneyOperation].[MoneyOperationDirection] > 0 then [MoneyOperation].[Value] else 0 end) as [Income],
		sum(case when [MoneyOperation].[MoneyOperationDirection] < 0 then [MoneyOperation].[Value] else 0 end) as [Expense]
	from 
		[MoneyOperation] left outer join [MoneyOperation] as [P]
			on ([MoneyOperation].[ParentId] = [P].[Id])
	where
		[MoneyOperation].[DocumentDate] > @PeriodStart and [MoneyOperation].[DocumentDate] <= @PeriodEnd
	and
		(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
	and
		(@BankAccountId is null or [MoneyOperation].[BankAccountId] = @BankAccountId)
	and
		[MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c))
	and
		([MoneyOperation].[ParentId] is null or [P].[MoneyOperationTypeId] <> 4 or [MoneyOperation].[MoneyOperationTypeId] = 8)
	group by
		[MoneyOperation].[MoneyOperationTypeId],
		[MoneyOperation].[BudgetItemGroupId],
		[MoneyOperation].[BudgetItemId]
	union all
	select 
		3 as [ViewGroup],
		null as [MoneyOperationTypeId],
		null as [BudgetItemGroupId],
		null as [BudgetItemId],
		sum(case when [MoneyOperation].[MoneyOperationDirection] > 0 then [MoneyOperation].[Value] else 0 end) as [Income],
		sum(case when [MoneyOperation].[MoneyOperationDirection] < 0 then [MoneyOperation].[Value] else 0 end) as [Expense]
	from 
		[MoneyOperation] left outer join [MoneyOperation] as [P]
			on ([MoneyOperation].[ParentId] = [P].[Id])
	where
		[MoneyOperation].[DocumentDate] <= @PeriodEnd
	and
		(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
	and
		(@BankAccountId is null or [MoneyOperation].[BankAccountId] = @BankAccountId)
	and
		[MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c))
	and
		([MoneyOperation].[ParentId] is null or [P].[MoneyOperationTypeId] <> 4 or [MoneyOperation].[MoneyOperationTypeId] = 8)
	for xml auto, root('ArrayOfMoneyOperation');

	return 0;
end

go

grant execute on [dbo].[MoneyOperationReportByOperationType] to public;
go
