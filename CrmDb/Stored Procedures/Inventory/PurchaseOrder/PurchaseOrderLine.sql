CREATE TABLE [dbo].[PurchaseOrderLine]
(
	[PurchaseOrderLineId] TIdentifier not null identity primary key,
	[PurchaseOrderId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[Amount] TAmount not null,
	[Cost] [TMoney] not null, 
    CONSTRAINT [FK_PurchaseOrderLine_PurchaseOrder] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [PurchaseOrder]([Id]), 
    CONSTRAINT [FK_PurchaseOrderLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
