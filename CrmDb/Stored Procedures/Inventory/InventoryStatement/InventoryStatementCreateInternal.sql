create procedure [dbo].[InventoryStatementCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('InventoryStatement') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[InventoryStatement]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [StoragePlaceId], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @StoragePlaceId, @Comments, getdate(),
		@CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

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
