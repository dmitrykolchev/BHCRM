CREATE TABLE [dbo].[InventoryStatementLine]
(
	[InventoryStatementLineId] TIdentifier not null identity primary key,
	[InventoryStatementId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[ExpectedAmount] TAmount not null, 
	[Amount] TAmount not null, 
    [Cost] TMoney not null, 
    CONSTRAINT [FK_InventoryStatementLine_InventoryStatement] FOREIGN KEY ([InventoryStatementId]) REFERENCES [dbo].[InventoryStatement]([Id]), 
    CONSTRAINT [FK_InventoryStatementLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id])
)
