create procedure [dbo].[ProductDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[ProductSupplier] where [ProductId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[Product] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
