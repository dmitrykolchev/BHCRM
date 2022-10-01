create procedure [dbo].[PurchaseOrderCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@SupplierId TIdentifier,
			@PurchaseInvoiceId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@SupplierId = T.c.value('@SupplierId', 'TIdentifier'),
		@PurchaseInvoiceId = T.c.value('@PurchaseInvoiceId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('PurchaseOrder') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[PurchaseOrder]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [StoragePlaceId], [SupplierId], [PurchaseInvoiceId],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @StoragePlaceId, @SupplierId, @PurchaseInvoiceId, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[PurchaseOrderLine]
		([PurchaseOrderId], [ProductId], [Amount], [Cost])
	select
		@Id,
		T.c.value('@ProductId', 'int'),
		T.c.value('@Amount', 'TAmount'),
		T.c.value('@Cost', 'TMoney')
	from	
		@xml.nodes('PurchaseOrder/Lines/PurchaseOrderLine') as T(c)
	if @@error <> 0
		return 1;


	update [dbo].[PurchaseOrder]
	set
		[TotalCost] = (select sum([Amount] * [Cost]) from [dbo].[PurchaseOrderLine] where [PurchaseOrderId] = @Id)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
