CREATE TABLE [dbo].[DocumentPropertyMetadata]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[DocumentTypeId] int not null,
	[PropertyCategory] nvarchar(256) NOT null,
	[PropertyValueType] int not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_DocumentPropertyMetadata_DocumentType] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentType]([Id])
)
