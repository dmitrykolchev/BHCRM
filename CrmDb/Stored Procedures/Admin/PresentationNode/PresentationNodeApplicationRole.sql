CREATE TABLE [dbo].[PresentationNodeApplicationRole]
(
	[PresentationNodeId] TIdentifier not null,
	[ApplicationRoleId] TIdentifier not null, 
    CONSTRAINT [FK_PresentationNodeApplicationRole_PresentationNode] FOREIGN KEY ([PresentationNodeId]) REFERENCES [PresentationNode]([Id]), 
    CONSTRAINT [FK_PresentationNodeApplicationRole_ApplicationRole] FOREIGN KEY ([ApplicationRoleId]) REFERENCES [ApplicationRole]([Id]), 
    CONSTRAINT [PK_PresentationNodeApplicationRole] PRIMARY KEY ([PresentationNodeId],[ApplicationRoleId])

)
