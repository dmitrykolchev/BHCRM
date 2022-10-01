create procedure [dbo].[MasterMenuUpdateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('MasterMenu') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Product]
	set
		[OrganizationId] = @OrganizationId,
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
		[ModifiedBy] = @UserId
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


	if exists(select * from [dbo].[MasterMenuData] where [Id] = @Id)
	begin
		update [dbo].[MasterMenuData]
		set
			[DishIngredientId] = @DishIngredientId,
			[DishTypeId] = @DishTypeId,
			[DishSubtypeId] = @DishSubtypeId,
			[DishCourseId] = @DishCourseId,
			[DishOccasionId] = @DishOccasionId,
			[DishWorldId] = @DishWorldId,
			[DishServingMask] = @DishServingMask,
			[DishCookingMethodId] = @DishCookingMethodId,
			[SeasonMask] = @SeasonMask,
			[ServiceRequestTypeMask] = @ServiceRequestTypeMask,
			[ServingAmount] = @ServingAmount
		where
			[Id] = @Id;
		if @@error <> 0
			return 1;
	end
	else
	begin	
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
	end

	return 0;
end
