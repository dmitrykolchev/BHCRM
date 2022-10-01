CREATE TABLE [dbo].[ProjectTemplate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[ProjectTypeId] TIdentifier not null,
	[Duration] int not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion NOT NULL, 
	CONSTRAINT [FK_ProjectTemplate_ProjectType] FOREIGN KEY ([ProjectTypeId]) REFERENCES [ProjectType]([Id])
)
