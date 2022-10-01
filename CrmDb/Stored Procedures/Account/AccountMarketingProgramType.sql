CREATE TABLE [dbo].[AccountMarketingProgramType]
(
	[AccountMarketingProgramTypeId] int not null identity primary key,
	[MarketingProgramTypeId] TIdentifier not null,
	[AccountId] TIdentifier not null,
	[ContactId] TIdentifier null, 
    CONSTRAINT [FK_AccountMarketingProgramType_MarketingProgramType] FOREIGN KEY ([MarketingProgramTypeId]) REFERENCES [MarketingProgramType]([Id]), 
    CONSTRAINT [FK_AccountMarketingProgramType_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_AccountMarketingProgramType_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Employee]([Id])
)
