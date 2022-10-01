CREATE TABLE [dbo].[DocumentReport]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[Code] varchar(128) null,
	[FileAs] TName not null,
	[DocumentTypeId] TIdentifier not null,
	[ReportPath] nvarchar(1024) not null,
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL
)
