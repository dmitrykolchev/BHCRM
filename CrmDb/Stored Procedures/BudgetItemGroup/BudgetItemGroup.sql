CREATE TABLE [dbo].[BudgetItemGroup]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[Code] TCode not null,
	[FileAs] TName not null,
	[BudgetItemGroupType] int not null default(1),
	[IsExpenseGroup] bit not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null
)
