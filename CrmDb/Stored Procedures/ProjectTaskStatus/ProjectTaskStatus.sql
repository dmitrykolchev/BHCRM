CREATE TABLE [dbo].[ProjectTaskStatus]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Color] int not null default(16777215),
	[Complete] decimal(4,2) not null default(0),
	[ProjectTaskState] TState not null default(1),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
)
