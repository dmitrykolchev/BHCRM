CREATE TABLE [dbo].[DocumentCategory]
(
	[DocumentTypeId] TIdentifier not null,
	[DocumentId] TIdentifier not null,
	[CategoryId] TIdentifier not null, 
    constraint [PK_DocumentCategory] primary key ([DocumentTypeId], [DocumentId], [CategoryId])
)
