CREATE TABLE [dbo].[CalculationStatementTotal]
(
	[CalculationStatementId] TIdentifier not null primary key,
	[TotalPrice] TMoney null,
	[TotalCost] TMoney null, 
    CONSTRAINT [FK_CalculationStatementTotal_CalculationStatement] FOREIGN KEY ([CalculationStatementId]) REFERENCES [CalculationStatement]([Id])
)
