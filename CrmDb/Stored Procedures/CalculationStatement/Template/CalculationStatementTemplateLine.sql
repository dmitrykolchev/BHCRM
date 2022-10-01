CREATE TABLE [dbo].[CalculationStatementTemplateLine]
(
	[CalculationStatementTemplateLineId] int not null identity primary key,
	[CalculationStatementTemplateSectionId] int not null,
	[CalculationStatementTemplateId] TIdentifier not null,
	[OrdinalPosition] int not null,
	[ProductId] TIdentifier null,
	[FileAs] TName not null,
	[Comments] nvarchar(1024) null,
	[Duration] TAmount not null default(1),
	[Amount] TAmount not null,
	[DependsOnAmountOfPersons] bit not null default(0),
	[DependsOnEventDuration] bit not null default(0),
	[Price] TMoney not null,
	[Cost] TMoney not null, 
    CONSTRAINT [FK_CalculationStatementTemplateLine_Section] FOREIGN KEY ([CalculationStatementTemplateSectionId]) REFERENCES [CalculationStatementTemplateSection]([CalculationStatementTemplateSectionId]), 
    CONSTRAINT [FK_CalculationStatementTemplateLine_CalculationStatementTemplate] FOREIGN KEY ([CalculationStatementTemplateId]) REFERENCES [CalculationStatementTemplate]([Id]), 
    CONSTRAINT [FK_CalculationStatementTemplateLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),

)
