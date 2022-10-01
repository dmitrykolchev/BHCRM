CREATE TABLE [dbo].[WriteoffStatementLine]
(
	[WriteoffStatementLineId] TIdentifier not null identity primary key,
	[WriteoffStatementId] TIdentifier not null,
	[ProductId] TIdentifier not null,
	[Amount] TAmount not null, 
	[Cost] TMoney not null,
    CONSTRAINT [FK_WriteoffStatementLine_WriteoffStatement] FOREIGN KEY ([WriteoffStatementId]) REFERENCES [WriteoffStatement]([Id]), 
    CONSTRAINT [FK_WriteoffStatementLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
