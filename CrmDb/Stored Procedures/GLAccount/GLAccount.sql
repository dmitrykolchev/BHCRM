CREATE TABLE [dbo].[GLAccount]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Code] TCode not null,
	[ParentId] TIdentifier null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_GLAccount_ParentGLAccount] FOREIGN KEY ([ParentId]) REFERENCES [GLAccount]([Id]), 
)
