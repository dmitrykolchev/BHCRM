create procedure [dbo].[UpdateProductCost]
as
begin
	set nocount on;

	with [C] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([IncomingAmount] - [OutgoingAmount]),
			sum(([IncomingAmount] - [OutgoingAmount]) * [Cost])
		from
			[InventoryOperation]
		where
			[IncomingAmount] <> 0 or [OutgoingAmount] <> 0
		group by
			[ProductId]
	)
	update [dbo].[Product]
	set
		[StandardCost] = (case when [C].[Amount] <= 0 then [Product].[StandardCost] else [C].[TotalCost] / [C].[Amount] end)
	from
		[Product] inner join [C]
			on ([Product].[Id] = [C].[ProductId])
	if @@error <> 0
		return 1;

	return 0;
end