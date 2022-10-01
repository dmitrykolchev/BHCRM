CREATE TABLE [dbo].[AccountRelation]
(
	[AccountId] TIdentifier not null,
	[RelatedAccountId] TIdentifier not null,
	[RelationTypeId] TIdentifier not null, 
    CONSTRAINT [FK_AccountRelation_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_AccountRelation_RelatedAccount] FOREIGN KEY ([RelatedAccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_AccountRelation_RelationType] FOREIGN KEY ([RelationTypeId]) REFERENCES [RelationType]([Id]), 
    CONSTRAINT [PK_AccountRelation] PRIMARY KEY ([AccountId], [RelatedAccountId], [RelationTypeId])
)
