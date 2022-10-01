create table [dbo].[Reason]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[ReasonTypeId] TIdentifier not null default(1),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_Reason_ReasonType] FOREIGN KEY ([ReasonTypeId]) REFERENCES [ReasonType]([Id]),
)
