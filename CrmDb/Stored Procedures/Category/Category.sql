create table [dbo].[Category]
(
	[Id] TIdentifier not null primary key identity,
	[State] TState not null,
	[FileAs] TName not null,
	[Color] int not null,
	[DocumentTypeId] int not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion NOT NULL, 
    CONSTRAINT [FK_Category_DocumentType] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentType]([Id])
)
