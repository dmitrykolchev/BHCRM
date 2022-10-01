CREATE TABLE [dbo].[PurchaseOrder]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Number] TCode not null,
	[DocumentDate] date not null,
	[OrganizationId] TIdentifier not null,
	[StoragePlaceId] TIdentifier not null,
	[SupplierId] TIdentifier not null,
	[PurchaseInvoiceId] TIdentifier null,
	[TotalCost] TMoney not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_PurchaseOrder_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_PurchaseOrder_StoragePlace] FOREIGN KEY ([StoragePlaceId]) REFERENCES [StoragePlace]([Id]), 
    CONSTRAINT [FK_PurchaseOrder_Account] FOREIGN KEY ([SupplierId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_PurchaseOrder_PurchaseInvoice] FOREIGN KEY ([PurchaseInvoiceId]) REFERENCES [PurchaseInvoice]([Id]),

)
