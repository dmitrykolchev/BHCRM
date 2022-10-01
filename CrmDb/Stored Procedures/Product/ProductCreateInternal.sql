create procedure [dbo].[ProductCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Product') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Product]
		([State], [OrganizationId], [ProductClass], [Code], [FileAs], [FullName], [AbstractProductId],
		[ProductTypeId], [ProductCategoryId], [ProductSubcategoryId], [ServiceLevelId], [AllowNegativeBalance], [CountryId],
		[Manufacturer], [SupplierId], [ItemColorId], [PriceMarginId],
		[UnitOfMeasureId], [Size], [SizeUnitOfMeasureId], [Weight], [WeightUnitOfMeasureId],
		[DiscontinuedDate], [Picture], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @OrganizationId, @ProductClass, @Code, @FileAs, @FullName, @AbstractProductId, @ProductTypeId,
		@ProductCategoryId, @ProductSubcategoryId, @ServiceLevelId, @AllowNegativeBalance, @CountryId, @Manufacturer, @SupplierId,
		@ItemColorId, @PriceMarginId, @UnitOfMeasureId, @Size,
		@SizeUnitOfMeasureId, @Weight, @WeightUnitOfMeasureId, @DiscontinuedDate, @Picture, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

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
