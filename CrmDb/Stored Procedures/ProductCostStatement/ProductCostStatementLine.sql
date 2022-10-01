CREATE TABLE [dbo].[ProductCostStatementLine]
(
	[ProductCostStatementLineId] TIdentifier not null identity primary key,
	[ProductCostStatementId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[Cost] TMoney not null, 
    CONSTRAINT [FK_ProductCostStatementLine_ProductCostStatement] FOREIGN KEY ([ProductCostStatementId]) REFERENCES [ProductCostStatement]([Id]), 
    CONSTRAINT [FK_ProductCostStatementLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
