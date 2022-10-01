create procedure [dbo].[PurchaseOrderChangeStateInternal]  @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int = [dbo].[GetCurrentUserId](), 
			@DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('PurchaseOrder'),
			@CurrentState TState, @result int;

	select
		@CurrentState = [State]
	from
		[dbo].[PurchaseOrder]
	where
		[Id] = @Id;

	if @CurrentState = 1 and @NewState = 2 
	begin
		insert into [dbo].[InventoryOperation]
			([DocumentTypeId], [DocumentId], [OrganizationId], [StoragePlaceId], [OperationDate], [ProductId], [IncomingAmount], [OutgoingAmount], [ReservedAmount], [Cost], [Price])
		select
			@DocumentTypeId,
			@Id,
			[PurchaseOrder].[OrganizationId],
			[PurchaseOrder].[StoragePlaceId],
			getdate(),
			[PurchaseOrderLine].[ProductId],
			[PurchaseOrderLine].Amount,
			0, 
			0,
			[PurchaseOrderLine].[Cost],
			0
		from
			[dbo].[PurchaseOrder] inner join [dbo].[PurchaseOrderLine]
				on ([PurchaseOrder].[Id] = [PurchaseOrderLine].[PurchaseOrderId])
		where
			[PurchaseOrder].[Id] = @Id;
		if @@error <> 0
			return 1;
	end;
	else if @CurrentState = 2 and @NewState = 1
	begin
		delete from [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
		if @@error <> 0
			return 1;
	end;

	update [dbo].[PurchaseOrder]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [State] <> @NewState;
	if @@error <> 0
		return 1;

	exec @result = [dbo].[UpdateProductCost];
	if @@error <> 0 or @result <> 0
		return 1;

	return 0;
end
