CREATE PROCEDURE [dbo].[CateringTypeCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[CateringTypeCreateInternal] @xml, @Id out;

	exec [dbo].[CateringTypeGet] @Id;

	return 0;
end
