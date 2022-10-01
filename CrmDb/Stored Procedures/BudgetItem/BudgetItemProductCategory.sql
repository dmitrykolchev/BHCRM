CREATE TABLE [dbo].[BudgetItemProductCategory]
(
	[BudgetItemId] TIdentifier not null,
	[ProductCategoryId] TIdentifier not null,
    CONSTRAINT [PK_BudgetItemProductCategory] PRIMARY KEY ([BudgetItemId], [ProductCategoryId]), 
    CONSTRAINT [FK_BudgetItemProductCategory_BudgetItem] FOREIGN KEY ([BudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_BudgetItemProductCategory_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id])
)
