create procedure [dbo].[PriceMarginDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[PriceMargin] where [Id] = @Id;

	return 0;
end
