CREATE TABLE [dbo].[DocumentTransitionAccess]
(
	[DocumentTransitionId] TIdentifier not null,
	[ApplicationRoleId] TIdentifier not null, 
    CONSTRAINT [FK_DocumentTransitionAccess_DocumentTransition] FOREIGN KEY ([DocumentTransitionId]) REFERENCES [DocumentTransition]([Id]), 
    CONSTRAINT [FK_DocumentTransitionAccess_ApplicationRole] FOREIGN KEY ([ApplicationRoleId]) REFERENCES [ApplicationRole]([Id]), 
    CONSTRAINT [PK_DocumentTransitionAccess] PRIMARY KEY ([ApplicationRoleId], [DocumentTransitionId])
)
