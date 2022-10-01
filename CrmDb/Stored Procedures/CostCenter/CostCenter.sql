CREATE TABLE [dbo].[CostCenter]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[AccountId] TIdentifier not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion NOT NULL, 
    CONSTRAINT [FK_CostCenter_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id])
)
