CREATE PROCEDURE [dbo].[DocumentTypeEntryUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentTypeEntryUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentTypeEntryGet] @Id;

	return 0;
end
