CREATE TABLE [dbo].[ProjectTaskTemplate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[TaskNo] int not null default(0),
	[FileAs] TName not null,
	[ProjectTemplateId] TIdentifier not null,
	[ProjectMemberRoleId] TIdentifier NOT null,
	[IsMilestone] bit not null default(0),
	[TaskStartOffset] int not null,
	[TaskDuration] int not null,
	[Importance] TIdentifier not null default(2),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_ProjectTaskTemplate_ProjectTemplate] FOREIGN KEY ([ProjectTemplateId]) REFERENCES [ProjectTemplate]([Id]), 
    CONSTRAINT [FK_ProjectTaskTemplate_ProjectMemberRole] FOREIGN KEY ([ProjectMemberRoleId]) REFERENCES [ProjectMemberRole]([Id])
)
