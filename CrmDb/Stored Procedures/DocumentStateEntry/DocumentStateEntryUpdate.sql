CREATE PROCEDURE [dbo].[DocumentStateEntryUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentStateEntryUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentStateEntryGet] @Id;

	return 0;
end
