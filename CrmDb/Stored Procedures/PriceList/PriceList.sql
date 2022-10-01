CREATE TABLE [dbo].[PriceList]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Number] TCode not null,
	[DocumentDate] date not null,
	[OrganizationId] TIdentifier not null,
	[ProductCategoryId] TIdentifier null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_PriceList_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_PriceList_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id])
)
