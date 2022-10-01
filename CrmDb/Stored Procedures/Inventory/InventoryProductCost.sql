CREATE TABLE [dbo].[InventoryProductCost]
(
	[ProductId] TIdentifier not null,
	[Amount] TAmount not null,
	[TotalCost] TMoney not null, 
    CONSTRAINT [FK_InventoryProductCost_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [PK_InventoryProductCost] PRIMARY KEY ([ProductId])
)
