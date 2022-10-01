CREATE TABLE [dbo].[PriceListLine]
(
	[PriceListLineId] TIdentifier not null identity primary key,
	[PriceListId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[PriceMarginId] TIdentifier not null,
	[Price] TMoney null, 
    CONSTRAINT [FK_PriceListLine_PriceList] FOREIGN KEY ([PriceListId]) REFERENCES [PriceList]([Id]), 
    CONSTRAINT [FK_PriceListLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_PriceListLine_PriceMargin] FOREIGN KEY ([PriceMarginId]) REFERENCES [PriceMargin]([Id])
)
