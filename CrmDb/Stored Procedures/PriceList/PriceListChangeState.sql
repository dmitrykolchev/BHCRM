create procedure [dbo].[PriceListChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();
	begin transaction;

	update [dbo].[PriceList]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	if @NewState = 2
	begin
		update [Product]
		set
			[ListPrice] = [PriceListLine].[Price]
		from
			[Product] inner join [PriceListLine]
				on ([Product].[Id] = [PriceListLine].[ProductId] and [PriceListLine].[PriceListId] = @Id)
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	commit transaction;

	return 0;
end
