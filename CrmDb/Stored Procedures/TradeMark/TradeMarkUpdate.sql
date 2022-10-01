CREATE PROCEDURE [dbo].[TradeMarkUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[TradeMarkUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[TradeMarkGet] @Id;

	return 0;
end