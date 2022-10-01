CREATE PROCEDURE [dbo].[CateringTypeUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[CateringTypeUpdateInternal] @xml, @Id out;

	exec [dbo].[CateringTypeGet] @Id;

	return 0;
end
