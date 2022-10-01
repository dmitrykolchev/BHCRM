CREATE TABLE [dbo].[BudgetTemplateLine]
(
	[BudgetTemplateLineId] TIdentifier not null primary key identity, 
	[BudgetTemplateId] TIdentifier not null,
	[BudgetItemId] TIdentifier not null,
	[StandardValue] TMoney null,
    CONSTRAINT [FK_BudgetTemplateLine_BudgetTemplate] FOREIGN KEY ([BudgetTemplateId]) REFERENCES [BudgetTemplate]([Id]), 
    CONSTRAINT [FK_BudgetTemplateLine_BudgetItem] FOREIGN KEY ([BudgetItemId]) REFERENCES [BudgetItem]([Id])
)
