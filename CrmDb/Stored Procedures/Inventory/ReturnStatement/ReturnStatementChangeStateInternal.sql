CREATE PROCEDURE [dbo].[ReturnStatementChangeStateInternal] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int = [dbo].[GetCurrentUserId](), 
			@DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('ReturnStatement'),
			@CurrentState TState, @result int;

	select
		@CurrentState = [State]
	from
		[dbo].[ReturnStatement]
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	if @CurrentState = 1 and @NewState = 2 
	begin
		insert into [dbo].[InventoryOperation]
			([DocumentTypeId], [DocumentId], [OrganizationId], [StoragePlaceId], [OperationDate], [ProductId], [IncomingAmount], [OutgoingAmount], [ReservedAmount], [Cost], [Price])
		select
			@DocumentTypeId,
			@Id,
			[ReturnStatement].[OrganizationId],
			[ReturnStatement].[StoragePlaceId],
			getdate(),
			[ReturnStatementLine].[ProductId],
			[ReturnStatementLine].[Amount],
			0, 
			0,
			[ReturnStatementLine].[Cost],
			[ReturnStatementLine].[Price]
		from
			[dbo].[ReturnStatement] inner join [dbo].[ReturnStatementLine]
				on ([ReturnStatement].[Id] = [ReturnStatementLine].[ReturnStatementId])
		where
			[ReturnStatement].[Id] = @Id;
		if @@error <> 0
			return 1;
	end;
	else if @CurrentState = 2 and @NewState = 1
	begin
		delete from [dbo].[InventoryOperation] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
		if @@error <> 0
			return 1;
	end;

	update [dbo].[ReturnStatement]
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
end;
