CREATE TABLE [dbo].[InventoryStatement]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Number] TCode not null,
	[DocumentDate] date not null,
	[OrganizationId] TIdentifier not null,
	[StoragePlaceId] TIdentifier not null,
	[TotalCost] TMoney not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_InventoryStatement_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Account]([Id]), 
    CONSTRAINT [FK_InventoryStatement_StoragePlace] FOREIGN KEY ([StoragePlaceId]) REFERENCES [dbo].[StoragePlace]([Id]), 
)
