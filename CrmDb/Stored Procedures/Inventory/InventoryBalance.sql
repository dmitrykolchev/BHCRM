CREATE TABLE [dbo].[InventoryBalance]
(
	[ProductId] TIdentifier not null,
	[StoragePlaceId] TIdentifier not null,
	[Amount] TAmount not null, 
	[AllowNegativeBalance] bit not null default(0),
    CONSTRAINT [FK_InventoryBalance_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_InventoryBalance_StoragePlace] FOREIGN KEY ([StoragePlaceId]) REFERENCES [StoragePlace]([Id]), 
    CONSTRAINT [PK_InventoryBalance] PRIMARY KEY ([ProductId], [StoragePlaceId]), 
    CONSTRAINT [CK_InventoryBalance_Amount] CHECK (([AllowNegativeBalance] = 0 and [Amount] >= 0) or [AllowNegativeBalance] <> 0)
)
