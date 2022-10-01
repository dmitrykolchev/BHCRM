CREATE PROCEDURE [dbo].[MasterMenuCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[MasterMenuCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[MasterMenuGet] @Id;

	return 0;
end
