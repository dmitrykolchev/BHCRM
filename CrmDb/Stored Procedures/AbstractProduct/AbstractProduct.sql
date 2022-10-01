CREATE TABLE [dbo].[AbstractProduct]
(
	[Id] TIdentifier not null primary key identity,
	[State] TState not null,
	[FileAs] TName not null,
	[FullName] nvarchar(1024) null,
	[ProductTypeId] TIdentifier not null default(1),
	[ProductCategoryId] TIdentifier not null,
	[ProductSubcategoryId] TIdentifier null,
	[UnitOfMeasureId] TIdentifier not null,
	[Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_AbstractProduct_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([Id]), 
    CONSTRAINT [FK_AbstractProduct_ProductSubcategory] FOREIGN KEY ([ProductSubcategoryId]) REFERENCES [dbo].[ProductSubcategory]([Id]),
	CONSTRAINT [FK_AbstractProduct_UnitOfMeasure] FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [dbo].[UnitOfMeasure]([Id]), 
    CONSTRAINT [FK_AbstractProduct_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType]([Id])
)
