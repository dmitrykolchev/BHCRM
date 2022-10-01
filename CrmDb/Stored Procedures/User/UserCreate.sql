CREATE PROCEDURE [dbo].[UserCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;
	
	begin transaction;

	exec @result = [dbo].[UserCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[UserGet] @Id;

	return 0;
end
