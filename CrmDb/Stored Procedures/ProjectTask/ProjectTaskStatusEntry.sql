CREATE TABLE [dbo].[ProjectTaskStatusEntry]
(
	[ProjectTaskStatusEntryId] int not null primary key identity,
	[ProjectTaskId] TIdentifier not null,
	[ProjectTaskStatusId] TIdentifier null,
	[ProjectTaskStatus] nvarchar(1024) null,
	[Color] int not null default(16777215),
    [Created] datetime not null, 
    [CreatedBy] int not null, 
)
