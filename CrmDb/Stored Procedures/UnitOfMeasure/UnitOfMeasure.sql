CREATE TABLE [dbo].[UnitOfMeasure]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[UnitOfMeasureClassId] TIdentifier null,
	[Code] TCode not null,
	[FileAs] TName not null,
	[Multiplier] TAmount not null default(1),
	[Divider] TAmount not null default(1),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_UnitOfMeasure_UnitOfMeasureClass] FOREIGN KEY ([UnitOfMeasureClassId]) REFERENCES [UnitOfMeasureClass]([Id])
)
