create procedure [dbo].[SalesOrderChangeStateInternal]  @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int = [dbo].[GetCurrentUserId](), @DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('SalesOrder'), @CurrentState TState;

	update [dbo].[SalesOrder]
	set
		@CurrentState = [State],
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	if @CurrentState = 1 and @NewState = 2
	begin
		update [dbo].[InventoryOperation]
		set
			[OutgoingAmount] = [ReservedAmount],
			[ReservedAmount] = 0
		where
			[DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
		if @@error <> 0
			return 1;
	end
	else if @CurrentState = 2 and @NewState = 1
	begin
		update [dbo].[InventoryOperation]
		set
			[ReservedAmount] = [OutgoingAmount],
			[OutgoingAmount] = 0
		where
			[DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
		if @@error <> 0
			return 1;
	end

	return 0;
end
