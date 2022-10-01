CREATE PROCEDURE [dbo].[ReturnStatementCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[ReturnStatementCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[ReturnStatementGet] @Id;

	return 0;
end
