CREATE TABLE [dbo].[DocumentState]
(
	[Id] TIdentifier not null identity primary key,
	[DocumentTypeId] int not null,
	[State] TState not null,
	[OrdinalPosition] int not null default(0),
	[Name] TName not null,
	[Caption] TName not null,
	[OverlayImage] varbinary(max) null,
	[Description] nvarchar(max) null,
    [Created] datetime not null default(getdate()), 
    [CreatedBy] int not null default(1), 
    [Modified] datetime not null default(getdate()), 
    [ModifiedBy] int not null default(1), 
    [RowVersion] rowversion not null, 
    constraint [UQ_DocumentState] unique ([DocumentTypeId], [State]), 
    constraint [FK_DocumentState_DocumentType] foreign key ([DocumentTypeId]) references [DocumentType]([Id])

)
