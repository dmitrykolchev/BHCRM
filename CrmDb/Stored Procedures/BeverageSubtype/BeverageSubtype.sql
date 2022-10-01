CREATE TABLE [dbo].[BeverageSubtype]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[BeverageTypeId] TIdentifier  not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_BeverageSubtype_BeverageType] FOREIGN KEY ([BeverageTypeId]) REFERENCES [BeverageType]([Id]), 
)
