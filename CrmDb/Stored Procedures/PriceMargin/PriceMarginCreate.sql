CREATE PROCEDURE [dbo].[PriceMarginCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[PriceMarginCreateInternal] @xml, @Id out;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec @result = [dbo].[PriceMarginGet] @Id;

	return 0;
end
