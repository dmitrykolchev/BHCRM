create procedure [dbo].[ProductUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@OrganizationId TIdentifier,
			@ProductClass TIdentifier,
			@Code TCode,
			@FileAs TName,
			@FullName nvarchar(1024),
			@AbstractProductId TIdentifier,
			@ProductTypeId TIdentifier,
			@ProductCategoryId TIdentifier,
			@ProductSubcategoryId TIdentifier,
			@ServiceLevelId TIdentifier,
			@AllowNegativeBalance bit,
			@CountryId TIdentifier,
			@Manufacturer nvarchar(64),
			@SupplierId TIdentifier,
			@ItemColorId TIdentifier,
			@PriceMarginId TIdentifier,
			@UnitOfMeasureId TIdentifier,
			@Size decimal(8,2),
			@SizeUnitOfMeasureId TIdentifier,
			@Weight decimal(8,2),
			@WeightUnitOfMeasureId TIdentifier,
			@DiscontinuedDate date,
			@Picture varbinary(max),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ProductClass = T.c.value('@ProductClass', 'TIdentifier'),
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@FullName = T.c.value('@FullName', 'nvarchar(1024)'),
		@AbstractProductId = T.c.value('@AbstractProductId', 'TIdentifier'),
		@ProductTypeId = T.c.value('@ProductTypeId', 'TIdentifier'),
		@ProductCategoryId = T.c.value('@ProductCategoryId', 'TIdentifier'),
		@ProductSubcategoryId = T.c.value('@ProductSubcategoryId', 'TIdentifier'),
		@ServiceLevelId = T.c.value('@ServiceLevelId', 'TIdentifier'),
		@AllowNegativeBalance = T.c.value('@AllowNegativeBalance', 'bit'),
		@CountryId = T.c.value('@CountryId', 'TIdentifier'),
		@Manufacturer = T.c.value('@Manufacturer', 'nvarchar(64)'),
		@SupplierId = T.c.value('@SupplierId', 'TIdentifier'),
		@ItemColorId = T.c.value('@ItemColorId', 'TIdentifier'),
		@PriceMarginId = T.c.value('@PriceMarginId', 'TIdentifier'),
		@UnitOfMeasureId = T.c.value('@UnitOfMeasureId', 'TIdentifier'),
		@Size = T.c.value('@Size', 'decimal(8,2)'),
		@SizeUnitOfMeasureId = T.c.value('@SizeUnitOfMeasureId', 'TIdentifier'),
		@Weight = T.c.value('@Weight', 'decimal(8,2)'),
		@WeightUnitOfMeasureId = T.c.value('@WeightUnitOfMeasureId', 'TIdentifier'),
		@DiscontinuedDate = T.c.value('@DiscontinuedDate', 'date'),
		@Picture = T.c.value('@Picture', 'varbinary(max)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Product') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Product]
	set
		[OrganizationId] = @OrganizationId,
		[ProductClass] = @ProductClass,
		[Code] = @Code,
		[FileAs] = @FileAs,
		[FullName] = @FullName,
		[AbstractProductId] = @AbstractProductId,
		[ProductTypeId] = @ProductTypeId,
		[ProductCategoryId] = @ProductCategoryId,
		[ProductSubcategoryId] = @ProductSubcategoryId,
		[ServiceLevelId] = @ServiceLevelId,
		[AllowNegativeBalance] = @AllowNegativeBalance,
		[CountryId] = @CountryId,
		[Manufacturer] = @Manufacturer,
		[SupplierId] = @SupplierId,
		[ItemColorId] = @ItemColorId,
		[PriceMarginId] = @PriceMarginId,
		[UnitOfMeasureId] = @UnitOfMeasureId,
		[Size] = @Size,
		[SizeUnitOfMeasureId] = @SizeUnitOfMeasureId,
		[Weight] = @Weight,
		[WeightUnitOfMeasureId] = @WeightUnitOfMeasureId,
		[DiscontinuedDate] = @DiscontinuedDate,
		[Picture] = @Picture,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	update [InventoryBalance]
	set
		[AllowNegativeBalance] = @AllowNegativeBalance
	where
		[ProductId] = @Id and [AllowNegativeBalance] <> @AllowNegativeBalance;
	if @@error <> 0
		return 1;


	delete [ProductSupplier] where [ProductId] = @Id;
	if @@error <> 0
		return 1;

	insert into [ProductSupplier]
		([ProductId], [SupplierId])
	select
		@Id,
		T.c.value('@SupplierId', 'TIdentifier')
	from
		@xml.nodes('Product/Suppliers/ProductSupplier') as T(c);
	if @@error <> 0
		return 1;


	return 0;
end
