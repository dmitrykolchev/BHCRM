CREATE TABLE [dbo].[OperatingBudgetLine]
(
	[OperatingBudgetLineId] int not null identity primary key,
	[OperatingBudgetId] TIdentifier not null,
	[CalculationStage] int not null,
	[DocumentTypeId] TIdentifier not null,
	[DocumentId] TIdentifier not null,
	[BudgetItemId] TIdentifier not null,
	[Tag] int not null default(1),
	[OrdinalPosition] TIdentifier not null,
	[AccountId] TIdentifier null,
	[FileAs] TName not null,
	[Comments] nvarchar(1024) null,
	[Amount] TAmount not null,
	[Price] TMoney not null, 
    CONSTRAINT [FK_OperatingBudgetLine_OperaingBudget] FOREIGN KEY ([OperatingBudgetId]) REFERENCES [OperatingBudget]([Id]), 
    CONSTRAINT [FK_OperatingBudgetLine_BudgetItem] FOREIGN KEY ([BudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_OperatingBudgetLine_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id])
)
