CREATE TABLE [dbo].[Division]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[AccountId] TIdentifier not null,
	[HeadOfDivisionId] TIdentifier null,
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL, 
    CONSTRAINT [FK_Division_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Division_Employee] FOREIGN KEY ([HeadOfDivisionId]) REFERENCES [Employee]([Id])
)
