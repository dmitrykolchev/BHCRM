CREATE PROCEDURE [dbo].[SeasonUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[SeasonUpdateInternal] @xml, @Id out;

	exec [dbo].[SeasonGet] @Id;

	return 0;
end
