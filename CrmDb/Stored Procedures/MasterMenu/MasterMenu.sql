CREATE VIEW [dbo].[MasterMenu]
as
	select
		[P].[Id],
		[P].[State],
		[P].[OrganizationId],
		[P].[Code],
		[P].[FileAs],
		[P].[FullName],
		[P].[AbstractProductId],
		[P].[ProductTypeId],
		[P].[ProductCategoryId],
		[P].[ProductSubcategoryId],
		[P].[ServiceLevelId],
		[P].[AllowNegativeBalance],
		[P].[CountryId],
		[P].[Manufacturer],
		[P].[ItemColorId],
		[P].[ListPrice],
		[P].[StandardCost],
		[P].[PriceMarginId],
		[P].[UnitOfMeasureId],
		[P].[Size],
		[P].[SizeUnitOfMeasureId],
		[P].[Weight],
		[P].[WeightUnitOfMeasureId],
		[P].[DiscontinuedDate],
		[P].[Picture],
		[M].[DishIngredientId],
		[M].[DishTypeId],
		[M].[DishSubtypeId], 
		[M].[DishCourseId],
		[M].[DishOccasionId],
		[M].[DishWorldId],
		[M].[DishServingMask],
		[M].[DishCookingMethodId],
		[M].[SeasonMask],
		[M].[ServiceRequestTypeMask], 
		[M].[ServingAmount], 
		[P].[Comments],
		[P].[Created],
		[P].[CreatedBy],
		[P].[Modified],
		[P].[ModifiedBy],
		[P].[RowVersion]

	from	
		[dbo].[Product] as [P] left join [dbo].[MasterMenuData] as [M]
			on ([P].[Id] = [M].[Id])
	where
		[P].[ProductClass] = 2;
