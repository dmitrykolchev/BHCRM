create procedure [dbo].[SalesOrderCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@CustomerId = T.c.value('@CustomerId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('SalesOrder') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[SalesOrder]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [StoragePlaceId], [BudgetId], [BudgetItemGroupId], [BudgetItemId], [CustomerId],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @StoragePlaceId, @BudgetId, @BudgetItemGroupId, @BudgetItemId, @CustomerId, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

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
		0,
		T.c.value('@Amount', 'decimal(18,6)'),
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
