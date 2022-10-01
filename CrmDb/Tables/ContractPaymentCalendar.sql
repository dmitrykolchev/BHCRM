CREATE TABLE [dbo].[ContractPaymentCalendar]
(
	[Id] TIdentifier not null identity primary key,
	[ContractId] TIdentifier not null,
	[PaymentDate] date not null,
	[Amount] TMoney not null, 
	[VAT] TMoney not null,
	[Comments] TSubject null,
    CONSTRAINT [FK_ContractPaymentCalendar_Contract] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[Contract]([Id])
)
