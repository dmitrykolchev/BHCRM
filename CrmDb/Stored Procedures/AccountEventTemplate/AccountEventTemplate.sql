CREATE TABLE [dbo].[AccountEventTemplate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[AccountEventTypeId] TIdentifier not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_AccountEventTemplate_AccountEventType] FOREIGN KEY ([AccountEventTypeId]) REFERENCES [AccountEventType]([Id])
)
