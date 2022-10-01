create procedure [dbo].[InventoryStatementUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('InventoryStatement') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[InventoryStatement]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[StoragePlaceId] = @StoragePlaceId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	delete [dbo].[InventoryStatementLine] where [InventoryStatementId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[InventoryStatementLine]
		([InventoryStatementId], [ProductId], [ExpectedAmount], [Amount], [Cost])
	select
		@Id,
		T.c.value('@ProductId', 'TIdentifier'),
		T.c.value('@ExpectedAmount', 'TAmount'),
		T.c.value('@Amount', 'TAmount'),
		T.c.value('@Cost', 'TMoney')
	from	
		@xml.nodes('InventoryStatement/Lines/InventoryStatementLine') as T(c);

	if @@error <> 0
		return 1;

	update [dbo].[InventoryStatement]
	set
		[TotalCost] = (select sum([Amount] * [Cost]) from [dbo].[InventoryStatementLine] where [InventoryStatementId] = @Id)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
