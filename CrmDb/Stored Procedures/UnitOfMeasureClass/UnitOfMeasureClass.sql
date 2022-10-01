CREATE TABLE [dbo].[UnitOfMeasureClass]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[BaseUnitOfMeasureId] TIdentifier null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_UnitOfMeasureClass_UnitOfMeasure] FOREIGN KEY ([BaseUnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id])
)
