CREATE PROCEDURE [dbo].[SeasonCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[SeasonCreateInternal] @xml, @Id out;

	exec [dbo].[SeasonGet] @Id;

	return 0;
end
