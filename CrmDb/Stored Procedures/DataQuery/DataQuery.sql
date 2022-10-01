CREATE TABLE [dbo].[DataQuery]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[DocumentElement] varchar(256) not null,
	[Selector] varchar(1024) null,
	[Value] varchar(1024) null,
	[SchemaName] nvarchar(128) not null,
	[ProcedureName] nvarchar(128) not null,
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL
)
