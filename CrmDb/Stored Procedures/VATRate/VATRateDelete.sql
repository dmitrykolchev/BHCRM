create procedure [dbo].[VATRateDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[VATRate] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
