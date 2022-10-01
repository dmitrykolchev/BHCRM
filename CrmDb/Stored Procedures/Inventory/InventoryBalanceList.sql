CREATE PROCEDURE [dbo].[InventoryBalanceList] @xml xml
as
begin
	exec [dbo].[InventoryBalanceBrowse] @xml;
end
	
