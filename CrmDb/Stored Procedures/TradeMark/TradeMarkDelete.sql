create procedure [dbo].[TradeMarkDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[TradeMark] where [Id] = @Id;

	return 0;
end
