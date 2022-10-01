CREATE TABLE [dbo].[BudgetItem]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[Code] TCode not null,
	[FileAs] TName not null,
	[BudgetItemGroupId] TIdentifier not null,
	[BudgetItemType] int not null default(1),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_BudgetItem_BudgetItemGroup] FOREIGN KEY ([BudgetItemGroupId]) REFERENCES [BudgetItemGroup]([Id])
)
