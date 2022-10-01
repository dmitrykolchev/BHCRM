CREATE PROCEDURE [dbo].[TradeMarkCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[TradeMarkCreateInternal] @xml, @Id out;

	exec @result = [dbo].[TradeMarkGet] @Id;

	return 0;
end
