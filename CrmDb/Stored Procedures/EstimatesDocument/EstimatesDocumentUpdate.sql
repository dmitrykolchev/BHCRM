CREATE PROCEDURE [dbo].[EstimatesDocumentUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[EstimatesDocumentUpdateInternal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[EstimatesDocumentGet] @Id;

	return 0;
end
