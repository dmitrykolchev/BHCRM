create procedure [dbo].[CalculationStatementList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[ServiceRequestId],
		[BudgetId],
		[CalculationStage],
		[IncomeBudgetItemId],
		[ExpenseBudgetItemId],
		[DependsOnAmountOfPersons],
		[AmountOnly],
		[VATRateId],
		[Margin],
		[Discount],
		[ResponsibleEmployeeId]
	from
		[dbo].[CalculationStatement]
	where
		(@Id is null or [Id] = @Id)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
