CREATE PROCEDURE [dbo].[InventoryBalanceBrowse] @filter xml
AS
begin
	set nocount on;
	
	declare @Id TIdentifier, @Presentation varchar(256);
	declare @AbstractProductId TIdentifier, @OrganizationId TIdentifier, @ProductCategoryId TIdentifier, @ProductSubcategoryId TIdentifier, 
			@ServiceLevelId TIdentifier, @SupplierId TIdentifier, @ProductTypeId TIdentifier, @AllStates bit, @BudgetItemId TIdentifier,
			@StoragePlaceId TIdentifier;


	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@AbstractProductId = T.c.value('AbstractProductId[1]', 'TIdentifier'),
		@ProductCategoryId = T.c.value('ProductCategoryId[1]', 'TIdentifier'),
		@ProductTypeId = T.c.value('ProductTypeId[1]', 'TIdentifier'),
		@SupplierId = T.c.value('SupplierId[1]', 'TIdentifier'),
		@ProductSubcategoryId = T.c.value('ProductSubcategoryId[1]', 'TIdentifier'),
		@ServiceLevelId = T.c.value('ServiceLevelId[1]', 'TIdentifier'),
		@BudgetItemId = T.c.value('BudgetItemId[1]', 'TIdentifier'),
		@StoragePlaceId = T.c.value('StoragePlaceId[1]', 'TIdentifier')
	from
		@filter.nodes('Filter') as T(c);


	with [B] ([ProductId], [StoragePlaceId], [IncomingAmount], [IncomingTotalCost], [OutgoingAmount], [OutgoingTotalCost], [ReservedAmount]) as
	(
		select
			[ProductId],
			[StoragePlaceId],
			sum([IncomingAmount]),
			sum([IncomingAmount] * [Cost]),
			sum([OutgoingAmount]),
			sum([OutgoingAmount] * [Cost]),
			sum([ReservedAmount])
		from
			[InventoryOperation]
		where
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId],
			[StoragePlaceId]
	)
	select
		[Product].[Id],
		[Product].[State],
		[Product].[OrganizationId],
		[Product].[ProductClass],
		[Product].[Code],
		[Product].[FileAs],
		[Product].[FullName],
		[Product].[AbstractProductId],
		[Product].[ProductTypeId],
		[Product].[ProductCategoryId],
		[Product].[ProductSubcategoryId],
		[Product].[ServiceLevelId],
		[Product].[CountryId],
		[Product].[Manufacturer],
		[Product].[SupplierId],
		[Product].[ListPrice],
		[Product].[PriceMarginId],
		[Product].[UnitOfMeasureId],
		[Product].[Size],
		[Product].[SizeUnitOfMeasureId],
		[Product].[Weight],
		[Product].[WeightUnitOfMeasureId],
		[Product].[DiscontinuedDate],
		[Product].[Comments],
		[Product].[Created],
		[Product].[CreatedBy],
		[Product].[Modified],
		[Product].[ModifiedBy],
		[Product].[RowVersion],
		[B].[StoragePlaceId],
		[B].[IncomingAmount],
		[B].[IncomingTotalCost],
		[B].[OutgoingAmount],
		[B].[OutgoingTotalCost],
		[B].[ReservedAmount]
	from
		[dbo].[Product] inner join [B]
			on ([Product].[Id] = [B].[ProductId])
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId)
	and
		(@SupplierId is null or [SupplierId] = @SupplierId)
	and
		(@ProductTypeId is null or [ProductTypeId] = @ProductTypeId)
	and
		(@AbstractProductId is null or [AbstractProductId] = @AbstractProductId)
	and
		(@ProductCategoryId is null or [ProductCategoryId] = @ProductCategoryId)
	and
		(@ProductSubcategoryId is null or [ProductSubcategoryId] = @ProductSubcategoryId)
	and 
		(@ServiceLevelId is null or ([ServiceLevelId] & @ServiceLevelId) <> 0);

	return 0;
end
go

grant execute on [dbo].[InventoryBalanceBrowse] to public;
go