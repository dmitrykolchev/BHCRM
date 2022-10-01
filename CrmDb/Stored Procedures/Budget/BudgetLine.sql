CREATE TABLE [dbo].[BudgetLine]
(
	[Id] TIdentifier not null identity primary key,
	[BudgetId] TIdentifier not null,
	[BudgetItemId] TIdentifier not null,
	[CalculationStage] int not null,
	[Value] TMoney not null
)
