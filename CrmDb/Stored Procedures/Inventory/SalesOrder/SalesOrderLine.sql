CREATE TABLE [dbo].[SalesOrderLine]
(
	[SalesOrderLineId] TIdentifier not null identity primary key,
	[SalesOrderId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[Amount] TAmount not null,
	[Cost] TMoney not null,
	[Price] [TMoney] not null, 
    CONSTRAINT [FK_SalesOrderLine_PurchaseOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder]([Id]), 
    CONSTRAINT [FK_SalesOrderLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
