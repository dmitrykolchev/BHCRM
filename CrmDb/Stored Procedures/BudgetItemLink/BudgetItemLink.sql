CREATE TABLE [dbo].[BudgetItemLink]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[IncomeBudgetItemId] TIdentifier not null,
	[ExpenseBudgetItemId] TIdentifier not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_BudgetItemLink_IncomeBudgetItem] FOREIGN KEY ([IncomeBudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_BudgetItemLink_ExpenseBudgetItem] FOREIGN KEY ([ExpenseBudgetItemId]) REFERENCES [BudgetItem]([Id]), 
)
