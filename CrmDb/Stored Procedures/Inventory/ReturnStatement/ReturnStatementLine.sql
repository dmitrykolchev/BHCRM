CREATE TABLE [dbo].[ReturnStatementLine]
(
	[ReturnStatementLineId] TIdentifier not null primary key identity,
	[ReturnStatementId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[Amount] TAmount not null,
	[Cost] TMoney not null, 
	[Price] TMoney not null,
    CONSTRAINT [FK_ReturnStatementLine_ReturnStatement] FOREIGN KEY ([ReturnStatementId]) REFERENCES [ReturnStatement]([Id]), 
    CONSTRAINT [FK_ReturnStatementLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
