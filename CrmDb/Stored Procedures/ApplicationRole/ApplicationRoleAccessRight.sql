CREATE TABLE [dbo].[ApplicationRoleAccessRight]
(
	[ApplicationRoleId] int not null,
	[AccessRightId] int not null, 
    CONSTRAINT [PK_ApplicationRoleAccessRight] PRIMARY KEY ([ApplicationRoleId], [AccessRightId]), 
    CONSTRAINT [FK_ApplicationRoleAccessRight_ApplicationRole] FOREIGN KEY ([ApplicationRoleId]) REFERENCES [ApplicationRole]([Id]), 
    CONSTRAINT [FK_ApplicationRoleAccessRight_AccessRight] FOREIGN KEY ([AccessRightId]) REFERENCES [AccessRight]([Id]),
)
