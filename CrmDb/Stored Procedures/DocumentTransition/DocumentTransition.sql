CREATE TABLE [dbo].[DocumentTransition]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[DocumentTypeId] int not null,
	[FromState] TState not null,
	[ToState] TState not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
)
