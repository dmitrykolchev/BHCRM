CREATE TABLE [dbo].[UserApplicationRole]
(
	[UserId] TIdentifier not null,
	[ApplicationRoleId] TIdentifier not null, 
    CONSTRAINT [PK_UserApplicationRole] PRIMARY KEY ([UserId], [ApplicationRoleId]), 
    CONSTRAINT [FK_UserApplicationRole_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserApplicationRole_ApplicationRole] FOREIGN KEY ([ApplicationRoleId]) REFERENCES [ApplicationRole]([Id])

)
