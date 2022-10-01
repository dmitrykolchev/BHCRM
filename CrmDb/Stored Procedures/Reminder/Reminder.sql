CREATE TABLE [dbo].[Reminder]
(
	[Id] TIdentifier not null primary key identity,
	[State] TState not null,
	[FileAs] TName not null,
	[StartDate] date not null,
	[DueDate] date not null,
	[ReminderTime] datetime not null,
	[UserId] TIdentifier not null,
	[DocumentTypeId] TIdentifier null,
	[DocumentId] TIdentifier null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_Reminder_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
