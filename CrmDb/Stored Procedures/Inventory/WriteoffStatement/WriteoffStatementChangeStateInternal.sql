create procedure [dbo].[WriteoffStatementChangeStateInternal] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int = [dbo].[GetCurrentUserId](),
			@DocumentTypeId int = [dbo].[GetDocumentTypeId]('WriteoffStatement'),
			@CurrentState TState;

	update [dbo].[WriteoffStatement]
	set
		@CurrentState = [State],
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	if @CurrentState = 1 and @NewState = 2 -- Утвердить
	begin
		insert into [dbo].[InventoryOperation]
			([DocumentTypeId], [DocumentId], [OrganizationId], [StoragePlaceId], [OperationDate], [ProductId], [IncomingAmount], [OutgoingAmount], [ReservedAmount], [Cost], [Price])
		select
			@DocumentTypeId,
			@Id,
			[WriteoffStatement].[OrganizationId],
			[WriteoffStatement].[StoragePlaceId],
			getdate(),
			[WriteoffStatementLine].[ProductId],
			0,
			[WriteoffStatementLine].Amount,
			0,
			[WriteoffStatementLine].[Cost],
			0
		from
			[WriteoffStatement] inner join [WriteoffStatementLine]
				on ([WriteoffStatement].[Id] = [WriteoffStatementLine].[WriteoffStatementId])
		where
			[WriteoffStatement].[Id] = @Id;
		if @@error <> 0
			return 1;
	end
	else if @CurrentState = 2 and @NewState = 1
	begin
		delete [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
		if @@error <> 0
			return 1;
	end

	return 0;
end
