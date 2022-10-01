CREATE TABLE [dbo].[ProductSupplier]
(
	[ProductId] TIdentifier not null,
	[SupplierId] TIdentifier not null, 
    CONSTRAINT [FK_ProductSupplier_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductSupplier_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [PK_ProductSupplier] PRIMARY KEY ([ProductId], [SupplierId]),
)
