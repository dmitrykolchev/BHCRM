create procedure [dbo].[MasterMenuCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@OrganizationId TIdentifier,
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
			@ItemColorId TIdentifier,
			@PriceMarginId TIdentifier,
			@UnitOfMeasureId TIdentifier,
			@Size decimal(8,2),
			@SizeUnitOfMeasureId TIdentifier,
			@Weight decimal(8,2),
			@WeightUnitOfMeasureId TIdentifier,
			@DiscontinuedDate date,
			@Picture varbinary(max),
			@DishIngredientId TIdentifier,
			@DishTypeId TIdentifier,
			@DishSubtypeId TIdentifier,
			@DishCourseId TIdentifier,
			@DishOccasionId TIdentifier,
			@DishWorldId TIdentifier,
			@DishServingMask TIdentifier,
			@DishCookingMethodId TIdentifier,
			@SeasonMask TIdentifier,
			@ServiceRequestTypeMask int,
			@ServingAmount TAmount,
			@Comments nvarchar(max);
	select
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
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
		@ItemColorId = T.c.value('@ItemColorId', 'TIdentifier'),
		--@ListPrice = T.c.value('@ListPrice', 'TMoney'),
		--@StandardCost = T.c.value('@StandardCost', 'TMoney'),
		@PriceMarginId = T.c.value('@PriceMarginId', 'TIdentifier'),
		@UnitOfMeasureId = T.c.value('@UnitOfMeasureId', 'TIdentifier'),
		@Size = T.c.value('@Size', 'decimal(8,2)'),
		@SizeUnitOfMeasureId = T.c.value('@SizeUnitOfMeasureId', 'TIdentifier'),
		@Weight = T.c.value('@Weight', 'decimal(8,2)'),
		@WeightUnitOfMeasureId = T.c.value('@WeightUnitOfMeasureId', 'TIdentifier'),
		@DiscontinuedDate = T.c.value('@DiscontinuedDate', 'date'),
		@Picture = T.c.value('@Picture', 'varbinary(max)'),
		@DishIngredientId = T.c.value('@DishIngredientId', 'TIdentifier'),
		@DishTypeId = T.c.value('@DishTypeId', 'TIdentifier'),
		@DishSubtypeId = T.c.value('@DishSubtypeId', 'TIdentifier'),
		@DishCourseId = T.c.value('@DishCourseId', 'TIdentifier'),
		@DishOccasionId = T.c.value('@DishOccasionId', 'TIdentifier'),
		@DishWorldId = T.c.value('@DishWorldId', 'TIdentifier'),
		@DishServingMask = T.c.value('@DishServingMask', 'TIdentifier'),
		@DishCookingMethodId = T.c.value('@DishCookingMethodId', 'TIdentifier'),
		@SeasonMask = T.c.value('@SeasonMask', 'TIdentifier'),
		@ServiceRequestTypeMask = T.c.value('@ServiceRequestTypeMask', 'int'),
		@ServingAmount = T.c.value('@ServingAmount', 'TAmount'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('MasterMenu') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Product]
		([State], [ProductClass], [OrganizationId], [Code], [FileAs], [FullName], [AbstractProductId], [ProductTypeId], [ProductCategoryId],
		[ProductSubcategoryId], [ServiceLevelId], [AllowNegativeBalance], [CountryId], [Manufacturer], [ItemColorId], 
		[PriceMarginId], [UnitOfMeasureId], [Size], [SizeUnitOfMeasureId], [Weight], [WeightUnitOfMeasureId],
		[DiscontinuedDate], [Picture], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 2, @OrganizationId, @Code, @FileAs, @FullName, @AbstractProductId, @ProductTypeId, @ProductCategoryId,
		@ProductSubcategoryId, @ServiceLevelId, @AllowNegativeBalance, @CountryId, @Manufacturer, @ItemColorId, 
		@PriceMarginId, @UnitOfMeasureId, @Size, @SizeUnitOfMeasureId, @Weight, @WeightUnitOfMeasureId,
		@DiscontinuedDate, @Picture, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	insert into [dbo].[MasterMenuData]
		([Id], [DishIngredientId], [DishTypeId], [DishSubtypeId], [DishCourseId],
		[DishOccasionId], [DishWorldId], [DishServingMask], [DishCookingMethodId], [SeasonMask],
		[ServiceRequestTypeMask], [ServingAmount])
	values
		(@Id, @DishIngredientId, @DishTypeId, @DishSubtypeId, @DishCourseId,
		@DishOccasionId, @DishWorldId, @DishServingMask, @DishCookingMethodId, @SeasonMask,
		@ServiceRequestTypeMask, @ServingAmount);

	if @@error <> 0
		return 1;

	return 0;
end
