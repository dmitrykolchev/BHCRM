CREATE TABLE [dbo].[PresentationNode]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Key] TName NOT null,
	[DefaultViewId] TIdentifier null,
	[OrdinalPosition] int not null default(0),
	[ViewControlTypeName] varchar(1024) null,
	[Parameter] TName null,
	[ParentId] TIdentifier null,
	[DocumentTypeId] int null,
	[SmallImageData] varbinary(max) null,
	[LargeImageData] varbinary(max) null,
	[NodeType] int not null default(1),
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL, 
    CONSTRAINT [FK_PresentationNode_PresentationNode] FOREIGN KEY ([ParentId]) REFERENCES [PresentationNode]([Id]), 
    CONSTRAINT [FK_PresentationNode_DefaultView] FOREIGN KEY ([DefaultViewId]) REFERENCES [PresentationNode]([Id])
)
