create table [dbo].[InventoryOperation]
(
	[InventiryOperationId] int not null identity primary key, 
    [DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[OrganizationId] TIdentifier not null,
	[StoragePlaceId] TIdentifier not null,
	[OperationDate] date not null,
	[ProductId] TIdentifier not null,
	[IncomingAmount] TAmount not null,
	[OutgoingAmount] TAmount not null,
	[ReservedAmount] TAmount not null,
	[Cost] TMoney not null,
	[Price] TMoney not null, 
    CONSTRAINT [FK_InventoryOperation_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_InventoryOperation_StoragePlace] FOREIGN KEY ([StoragePlaceId]) REFERENCES [StoragePlace]([Id]), 
    CONSTRAINT [FK_InventoryOperation_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)

GO

create trigger [dbo].[Trigger_InventoryOperation_Insert] ON [dbo].[InventoryOperation] for insert
as
begin
    set nocount on;
	with [I] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) as 
	(
		select
			[inserted].[ProductId],
			[inserted].[StoragePlaceId],
			[Product].[AllowNegativeBalance],
			sum([inserted].[IncomingAmount] - [inserted].[OutgoingAmount])
		from
			[inserted] inner join [Product]
				on ([inserted].[ProductId] = [Product].[Id])
		group by
			[inserted].[ProductId],
			[inserted].[StoragePlaceId],
			[Product].[AllowNegativeBalance]
	)
	merge [InventoryBalance]
	using (select [ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount] from [I]) as [source] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount])
		on	([InventoryBalance].[ProductId] = [source].[ProductId] and [InventoryBalance].[StoragePlaceId] = [source].[StoragePlaceId])
	when matched then
		update set [Amount] = [InventoryBalance].[Amount] + [source].[Amount]
	when not matched then
		insert 
			([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) 
		values
			([source].[ProductId], [source].[StoragePlaceId], [source].[AllowNegativeBalance], [source].[Amount]);
	if @@error <> 0
		rollback transaction;
end
GO

create trigger [dbo].[Trigger_InventoryOperation_Update] ON [dbo].[InventoryOperation] for update
as
begin
    set nocount on;
	with [I] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) as 
	(
		select
			[inserted].[ProductId],
			[inserted].[StoragePlaceId],
			[Product].[AllowNegativeBalance],
			sum([inserted].[IncomingAmount] - [inserted].[OutgoingAmount] - [deleted].[IncomingAmount] + [deleted].[OutgoingAmount])
		from
			[inserted] inner join [deleted]
				on ([inserted].[InventiryOperationId] = [deleted].[InventiryOperationId])
			inner join [Product]
				on ([inserted].[ProductId] = [Product].[Id])
		group by
			[inserted].[ProductId],
			[inserted].[StoragePlaceId],
			[Product].[AllowNegativeBalance]
	)
	merge [InventoryBalance]
	using (select [ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount] from [I]) as [source] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount])
		on	([InventoryBalance].[ProductId] = [source].[ProductId] and [InventoryBalance].[StoragePlaceId] = [source].[StoragePlaceId])
	when matched then
		update set [Amount] = [InventoryBalance].[Amount] + [source].[Amount]
	when not matched then
		insert 
			([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) 
		values
			([source].[ProductId], [source].[StoragePlaceId], [source].[AllowNegativeBalance], [source].[Amount]);
	if @@error <> 0
		rollback transaction;
end
GO

create trigger [dbo].[Trigger_InventoryOperation_Delete] ON [dbo].[InventoryOperation] for delete
as
begin
    set nocount on;
	with [I] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) as 
	(
		select
			[deleted].[ProductId],
			[deleted].[StoragePlaceId],
			[Product].[AllowNegativeBalance],
			sum(-[deleted].[IncomingAmount] + [deleted].[OutgoingAmount])
		from
			[deleted] inner join [Product]
				on ([deleted].[ProductId] = [Product].[Id])
		group by
			[deleted].[ProductId],
			[deleted].[StoragePlaceId],
			[Product].[AllowNegativeBalance]
	)
	merge [InventoryBalance]
	using (select [ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount] from [I]) as [source] ([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount])
		on	([InventoryBalance].[ProductId] = [source].[ProductId] and [InventoryBalance].[StoragePlaceId] = [source].[StoragePlaceId])
	when matched then
		update set [Amount] = [InventoryBalance].[Amount] + [source].[Amount]
	when not matched then
		insert 
			([ProductId], [StoragePlaceId], [AllowNegativeBalance], [Amount]) 
		values
			([source].[ProductId], [source].[StoragePlaceId], [source].[AllowNegativeBalance], [source].[Amount]);
	if @@error <> 0
		rollback transaction;
end
go