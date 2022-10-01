create procedure [dbo].[PriceListDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[PriceListLine] where [PriceListId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[PriceList] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
