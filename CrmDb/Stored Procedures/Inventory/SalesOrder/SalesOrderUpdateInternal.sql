create procedure [dbo].[SalesOrderUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@BudgetId TIdentifier,
			@BudgetItemGroupId TIdentifier,
			@BudgetItemId TIdentifier,
			@CustomerId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@CustomerId = T.c.value('@CustomerId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('SalesOrder') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int, @CurrentState TState;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[SalesOrder]
	set
		@CurrentState = [State],
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[StoragePlaceId] = @StoragePlaceId,
		[BudgetId] = @BudgetId,
		[BudgetItemGroupId] = @BudgetItemGroupId,
		[BudgetItemId] = @BudgetItemId,
		[CustomerId] = @CustomerId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	delete [dbo].[SalesOrderLine] where [SalesOrderId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[SalesOrderLine]
		([SalesOrderId], [ProductId], [Amount], [Cost], [Price])
	select
		@Id,
		T.c.value('@ProductId', 'int'),
		T.c.value('@Amount', 'decimal(18,6)'),
		T.c.value('@Cost', 'decimal(18,6)'),
		T.c.value('@Price', 'decimal(18,6)')
	from	
		@xml.nodes('SalesOrder/Lines/SalesOrderLine') as T(c)
	if @@error <> 0
		return 1;

	declare @DocumentTypeId int = [dbo].[GetDocumentTypeId]('SalesOrder');

	delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[InventoryOperation]
		([DocumentTypeId], [DocumentId], [OrganizationId], [StoragePlaceId], [OperationDate], [ProductId], [IncomingAmount], [OutgoingAmount], [ReservedAmount], [Cost], [Price])
	select
		@DocumentTypeId,
		@Id,
		@OrganizationId,
		@StoragePlaceId,
		@DocumentDate,
		T.c.value('@ProductId', 'int'),
		0,
		case when @CurrentState = 2 then T.c.value('@Amount', 'decimal(18,6)') else 0 end,
		case when @CurrentState = 1 then T.c.value('@Amount', 'decimal(18,6)') else 0 end,
		T.c.value('@Cost', 'decimal(18,6)'),
		T.c.value('@Price', 'decimal(18,6)')
	from
		@xml.nodes('SalesOrder/Lines/SalesOrderLine') as T(c)
	if @@error <> 0
		return 1;

	update [dbo].[SalesOrder]
	set
		[TotalCost] = (select sum([Amount] * [Cost]) from [dbo].[SalesOrderLine] where [SalesOrderId] = @Id),
		[TotalPrice] = (select sum([Amount] * [Price]) from [dbo].[SalesOrderLine] where [SalesOrderId] = @Id)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
