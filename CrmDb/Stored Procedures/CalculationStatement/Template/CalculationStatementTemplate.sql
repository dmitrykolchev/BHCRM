CREATE TABLE [dbo].[CalculationStatementTemplate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[BudgetTemplateId] TIdentifier not null,
	[IncomeBudgetItemId] TIdentifier null,
	[ExpenseBudgetItemId] TIdentifier null,
	[DependsOnAmountOfPersons] bit not null default(0),
	[AmountOnly] bit not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_CalculationStatementTemplate_BudgetTemplate] FOREIGN KEY ([BudgetTemplateId]) REFERENCES [BudgetTemplate]([Id]), 
    CONSTRAINT [FK_CalculationStatementTemplate_IncomeBudgetItem] FOREIGN KEY ([IncomeBudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_CalculationStatementTemplate_ExpenseBudgetItem] FOREIGN KEY ([ExpenseBudgetItemId]) REFERENCES [BudgetItem]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Учитывать только количество',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'CalculationStatementTemplate',
    @level2type = N'COLUMN',
    @level2name = N'AmountOnly'