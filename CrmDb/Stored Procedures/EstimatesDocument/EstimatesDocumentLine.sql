CREATE TABLE [dbo].[EstimatesDocumentLine]
(
	[EstimatesDocumentLineId] TIdentifier not null identity primary key,
	[EstimatesDocumentSectionId] TIdentifier not null,
	[EstimatesDocumentId] TIdentifier not null,
	[OrdinalPosition] int not null default(0),
	[ProductId] TIdentifier null,
	[FileAs] nvarchar(1024),
	[Comments] nvarchar(1024),
	[UnitOfMeasureId] TIdentifier null,
	[Amount] TAmount not null,
	[Price] TMoney not null, 
    [CashCost] TMoney not null,
	[NonCashCost] TMoney not null,
    CONSTRAINT [FK_EstimatesDocumentLine_EstimatesDocument] FOREIGN KEY ([EstimatesDocumentId]) REFERENCES [EstimatesDocument]([Id]), 
    CONSTRAINT [FK_EstimatesDocumentLine_EstimatesDocumentSection] FOREIGN KEY ([EstimatesDocumentSectionId]) REFERENCES [EstimatesDocumentSection]([EstimatesDocumentSectionId]), 
    CONSTRAINT [FK_EstimatesDocumentLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_EstimatesDocumentLine_UnitOfMeasureId] FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id]),
)
