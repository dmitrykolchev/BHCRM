create table [dbo].[DocumentAttachment]
(
	[Id] int not null identity primary key,
	[DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[BlobId] varchar(1024) not null,
	[BlobName] nvarchar(1024) not null,
    [Created] datetime not null default(getdate()), 
    [CreatedBy] int not null default(1), 
    [Modified] datetime not null default(getdate()), 
    [ModifiedBy] int not null default (1), 
    [RowVersion] rowversion not null, 
)

GO

CREATE INDEX [IX_DocumentAttachment_Document] ON [dbo].[DocumentAttachment] ([DocumentId], [DocumentTypeId])
