CREATE PROCEDURE [dbo].[PresentationNodeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[PresentationNodeCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[PresentationNodeGet] @Id;

	return 0;
end
