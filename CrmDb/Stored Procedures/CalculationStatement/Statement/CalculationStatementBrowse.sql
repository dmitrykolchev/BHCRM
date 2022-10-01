create procedure [dbo].[CalculationStatementBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256), @ServiceRequestId TIdentifier, @IncomeBudgetItemId TIdentifier, @ExpenseBudgetItemId TIdentifier,
			@CalculationStage int, @BudgetId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@ServiceRequestId = T.c.value('ServiceRequestId[1]', 'TIdentifier'),
		@BudgetId = T.c.value('BudgetId[1]', 'TIdentifier'),
		@IncomeBudgetItemId = T.c.value('IncomeBudgetItemId[1]', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('ExpenseBudgetItemId[1]', 'TIdentifier'),
		@CalculationStage = T.c.value('CalculationStage[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[CalculationStatement].[Id],
		[CalculationStatement].[State],
		[CalculationStatement].[FileAs],
		[CalculationStatement].[Number],
		[CalculationStatement].[DocumentDate],
		[CalculationStatement].[OrganizationId],
		[CalculationStatement].[ServiceRequestId],
		[CalculationStatement].[BudgetId],
		[CalculationStatement].[CalculationStage],
		[CalculationStatement].[IncomeBudgetItemId],
		[CalculationStatement].[ExpenseBudgetItemId],
		[CalculationStatement].[DependsOnAmountOfPersons],
		[CalculationStatement].[AmountOnly],
		[CalculationStatement].[VATRateId],
		[CalculationStatement].[Margin],
		[CalculationStatement].[Discount],
		[CalculationStatementTotal].[TotalPrice],
		[CalculationStatementTotal].[TotalCost],
		[CalculationStatement].[ResponsibleEmployeeId],
		[CalculationStatement].[Comments],
		[CalculationStatement].[Created],
		[CalculationStatement].[CreatedBy],
		[CalculationStatement].[Modified],
		[CalculationStatement].[ModifiedBy],
		[CalculationStatement].[RowVersion]
	from
		[dbo].[CalculationStatement] left outer join [CalculationStatementTotal]
			on ([CalculationStatement].[Id] = [CalculationStatementTotal].[CalculationStatementId])
	where
		(@Id is null or [Id] = @Id)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@ServiceRequestId is null or [ServiceRequestId] = @ServiceRequestId)
	and
		(@BudgetId is null or [BudgetId] = @BudgetId)
	and
		(@IncomeBudgetItemId is null or [IncomeBudgetItemId] = @IncomeBudgetItemId)
	and
		(@ExpenseBudgetItemId is null or [ExpenseBudgetItemId] = @ExpenseBudgetItemId)
	and
		(@CalculationStage is null or [CalculationStage] = @CalculationStage);

	return 0;
end
