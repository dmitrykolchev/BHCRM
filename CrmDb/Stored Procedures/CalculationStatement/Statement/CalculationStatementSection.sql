CREATE TABLE [dbo].[CalculationStatementSection]
(
	[CalculationStatementSectionId] int identity not null primary key,
	[CalculationStatementId] TIdentifier not null,
	[OrdinalPosition] int not null,
	[FileAs] TName not null,
	[ProductCategoryId] TIdentifier null, 
    [Comments] nvarchar(1024) null, 
	[StandardAmount] TAmount null,
    [StandardTotalCost] TMoney null, 
	[StandardTotalPrice] TMoney null,
    CONSTRAINT [FK_CalculationStatementSection_CalculationStatement] FOREIGN KEY ([CalculationStatementId]) REFERENCES [CalculationStatement]([Id]), 
    CONSTRAINT [FK_CalculationStatementSection_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id]), 
)
