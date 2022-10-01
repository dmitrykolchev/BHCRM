create procedure [dbo].[MoneyOperationBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256), @OrganizationId TIdentifier, @AccountId TIdentifier, @BudgetId TIdentifier, 
			@OperatingBudgetId TIdentifier, @ParentId TIdentifier, @MoneyOperationDirection int, @IncludeChildren bit, @SalesInvoiceId TIdentifier,
			@PurchaseInvoiceId TIdentifier, @MoneyOperationTypeId TIdentifier, @PeriodStart date, @PeriodEnd date;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@MoneyOperationTypeId = T.c.value('MoneyOperationTypeId[1]', 'TIdentifier'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@BudgetId = T.c.value('BudgetId[1]', 'TIdentifier'),
		@SalesInvoiceId = T.c.value('SalesInvoiceId[1]', 'TIdentifier'),
		@PurchaseInvoiceId = T.c.value('PurchaseInvoiceId[1]', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('OperatingBudgetId[1]', 'TIdentifier'),
		@ParentId = T.c.value('ParentId[1]', 'TIdentifier'),
		@MoneyOperationDirection = T.c.value('MoneyOperationDirection[1]', 'int'),
		@IncludeChildren = T.c.value('IncludeChildren[1]', 'bit')
	from
		@filter.nodes('/Filter') as T(c);

	if @ParentId is not null
		set @IncludeChildren = 1;

	if(@PeriodStart is null)
		set @PeriodStart = cast('0001-01-01' as date);

	if(@PeriodEnd is null)
		set @PeriodEnd = cast('9999-12-31' as date);

	select
		[MoneyOperation].[Id],
		[MoneyOperation].[State],
		[MoneyOperation].[FileAs],
		[MoneyOperation].[Number],
		[MoneyOperation].[DocumentDate],
		[MoneyOperation].[OrganizationId],
		[MoneyOperation].[ParentId],
		[MoneyOperation].[BankAccountId],
		[MoneyOperation].[MoneyOperationTypeId],
		[MoneyOperation].[MoneyOperationDirection],
		[MoneyOperation].[BudgetId],
		[Budget].[Number] as [BudgetNumber],
		[MoneyOperation].[OperatingBudgetId],
		[OperatingBudget].[DocumentDate] as [OperatingBudgetDate],
		[OperatingBudget].[Number] as [OperatingBudgetNumber],
		[MoneyOperation].[BudgetItemGroupId],
		[MoneyOperation].[BudgetItemId],
		[MoneyOperation].[SalesInvoiceId],
		[MoneyOperation].[PurchaseInvoiceId],
		[MoneyOperation].[AccountId],
		[MoneyOperation].[EmployeeId],
		[MoneyOperation].[Subject],
		[MoneyOperation].[Value],
		[MoneyOperation].[VATRateId],
		[MoneyOperation].[VATValue],
		(case when [MoneyOperationDirection] > 0 then [MoneyOperation].[Value] else null end) as [InValue],
		(case when [MoneyOperationDirection] < 0 then [MoneyOperation].[Value] else null end) as [OutValue],
		(case when [MoneyOperationDirection] > 0 then [MoneyOperation].[VATValue] else null end) as [InVATValue],
		(case when [MoneyOperationDirection] < 0 then [MoneyOperation].[VATValue] else null end) as [OutVATValue],
		[MoneyOperation].[Comments],
		[MoneyOperation].[Created],
		[MoneyOperation].[CreatedBy],
		[MoneyOperation].[Modified],
		[MoneyOperation].[ModifiedBy],
		[MoneyOperation].[RowVersion]
	from
		[dbo].[MoneyOperation] left outer join [dbo].[Budget]
			on ([MoneyOperation].[BudgetId] = [Budget].[Id])
		left outer join [dbo].[OperatingBudget]
			on ([MoneyOperation].[OperatingBudgetId] = [OperatingBudget].[Id])
	where
		([MoneyOperation].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [MoneyOperation].[OrganizationId] = @OrganizationId)
		and
		(@AccountId is null or [MoneyOperation].[AccountId] = @AccountId)
		and
		(@BudgetId is null or [MoneyOperation].[BudgetId] = @BudgetId)
		and
		(@OperatingBudgetId is null or [MoneyOperation].[OperatingBudgetId] = @OperatingBudgetId)
		and
		(@ParentId is null or [MoneyOperation].[ParentId] = @ParentId)
		and
		(@SalesInvoiceId is null or [MoneyOperation].[SalesInvoiceId] = @SalesInvoiceId)
		and
		(@PurchaseInvoiceId is null or [MoneyOperation].[PurchaseInvoiceId] = @PurchaseInvoiceId)
		and
		(@MoneyOperationDirection is null or [MoneyOperation].[MoneyOperationDirection] = @MoneyOperationDirection)
		and
		(@MoneyOperationTypeId is null or [MoneyOperation].[MoneyOperationTypeId] = @MoneyOperationTypeId)
		and
		(@IncludeChildren != 0 or (@IncludeChildren = 0 and [MoneyOperation].[ParentId] is null))
		and
		(@AllStates = 1 or [MoneyOperation].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
