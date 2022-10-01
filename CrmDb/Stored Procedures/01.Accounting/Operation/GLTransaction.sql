CREATE TABLE [dbo].[GLTransaction]
(
	[Id] TIdentifier not null primary key identity, 
	[GLOperationId] TIdentifier not null,
	[TransactionPart] tinyint not null,
	[GLAccountId] TIdentifier not null,
	[Amount] TAmount not null,
	[Price] TMoney not null,
)
