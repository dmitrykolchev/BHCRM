CREATE PROCEDURE [dbo].[DocumentTypeEntryCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[DocumentTypeEntryCreateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	
	commit transaction;

	exec @result = [dbo].[DocumentTypeEntryGet] @Id;

	return 0;
end
