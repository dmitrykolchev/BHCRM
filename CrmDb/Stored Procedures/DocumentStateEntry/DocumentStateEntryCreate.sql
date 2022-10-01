CREATE PROCEDURE [dbo].[DocumentStateEntryCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentStateEntryCreateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentStateEntryGet] @Id;

	return 0;
end
