CREATE TABLE [dbo].[AccountReason]
(
	[ReasonId] TIdentifier not null,
	[AccountId] TIdentifier not null, 
    CONSTRAINT [FK_AccountReason_Reason] FOREIGN KEY ([ReasonId]) REFERENCES [Reason]([Id]), 
    CONSTRAINT [FK_AccountReason_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [PK_AccountReason] PRIMARY KEY ([ReasonId], [AccountId]),
)
