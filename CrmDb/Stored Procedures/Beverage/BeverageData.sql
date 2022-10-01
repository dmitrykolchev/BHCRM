CREATE TABLE [dbo].[BeverageData]
(
	[Id] TIdentifier not null primary key,
	[BeverageTypeId] TIdentifier null,
	[BeverageSubtypeId] TIdentifier null,
	[BeveragePackId] TIdentifier null,
	[Volume] TAmount null,
	[BeverageMiscId] TIdentifier null, 
    CONSTRAINT [FK_BeverageData_BeverageType] FOREIGN KEY ([BeverageTypeId]) REFERENCES [BeverageType]([Id]), 
    CONSTRAINT [FK_BeverageData_BeverageSubtype] FOREIGN KEY ([BeverageSubtypeId]) REFERENCES [BeverageSubtype]([Id]), 
    CONSTRAINT [FK_BeverageData_BeveragePack] FOREIGN KEY ([BeveragePackId]) REFERENCES [BeveragePack]([Id]), 
    CONSTRAINT [FK_BeverageData_BeverageMisc] FOREIGN KEY ([BeverageMiscId]) REFERENCES [BeverageMisc]([Id]), 
    CONSTRAINT [FK_BeverageData_Product] FOREIGN KEY ([Id]) REFERENCES [Product]([Id])
)
