CREATE TABLE [dbo].[DocumentStateLog]
(
	[Id] TIdentifier not null identity primary key,
	[DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[FromState] TState not null,
	[ToState] TState not null,
	[Comments] nvarchar(max) null,
	[Data] xml null,
	[Created] datetime not null default(getdate()),
	[CreatedBy] int not null default(1)
)
