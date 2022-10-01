CREATE PROCEDURE [dbo].[ProductCostStatementUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[ProductCostStatementUpdateInternal] @xml, @Id out;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec @result = [dbo].[ProductCostStatementGet] @Id;

	return 0;
end
