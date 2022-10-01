CREATE TABLE [dbo].[EstimatesDocumentSection]
(
	[EstimatesDocumentSectionId] TIdentifier not null identity primary key,
	[EstimatesDocumentId] TIdentifier not null,
	[OrdinalPosition] int not null,
	[FileAs] TName not null,
	[ProductCategoryId] TIdentifier not null,
	[Comments] nvarchar(1024) null, 
    CONSTRAINT [FK_EstimatesDocumentSection_EstimatesDocument] FOREIGN KEY ([EstimatesDocumentId]) REFERENCES [EstimatesDocument]([Id]), 
    CONSTRAINT [FK_EstimatesDocumentSection_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id]),
)
