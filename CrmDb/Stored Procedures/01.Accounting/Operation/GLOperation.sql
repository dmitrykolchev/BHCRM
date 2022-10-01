CREATE TABLE [dbo].[GLOperation]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[OrganizationId] TIdentifier not null,
	[DocumentDate] date not null,
	[DocumentTypeId] int null,
	[DocumentId] TIdentifier null,
	[FileAs] TName not null,
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL
)
