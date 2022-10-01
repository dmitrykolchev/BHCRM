CREATE TABLE [dbo].[Contract]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[ParentContractId] TIdentifier null,
	[Number] TCode null,
	[ContractDate] date not null,
	[OrganizationId] TIdentifier not null,
	[AccountId] TIdentifier not null,
	[StartDate] date null,
	[EndDate] date null,
	[Amount] TMoney not null default(0),
	[VAT] TMoney not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_Contract_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Contract_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Contract_ParentContract] FOREIGN KEY ([ParentContractId]) REFERENCES [Contract]([Id])
)
