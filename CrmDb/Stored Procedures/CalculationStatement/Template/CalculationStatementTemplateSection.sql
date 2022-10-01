CREATE TABLE [dbo].[CalculationStatementTemplateSection]
(
	[CalculationStatementTemplateSectionId] int identity not null primary key,
	[CalculationStatementTemplateId] TIdentifier not null,
	[OrdinalPosition] int not null,
	[FileAs] TName not null,
	[ProductCategoryId] TIdentifier null, 
    [Comments] nvarchar(1024) null, 
    CONSTRAINT [FK_CalculationStatementTemplateSection_CalculationStatementTemplate] FOREIGN KEY ([CalculationStatementTemplateId]) REFERENCES [CalculationStatementTemplate]([Id]), 
    CONSTRAINT [FK_CalculationStatementTemplateSection_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id])
)
