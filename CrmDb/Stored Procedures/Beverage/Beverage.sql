CREATE VIEW [dbo].[Beverage]
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
		[P].[SupplierId],
		[P].[ItemColorId],
		[P].[ListPrice],
		[P].[StandardCost],
		[P].[UnitOfMeasureId],
		[P].[Size],
		[P].[SizeUnitOfMeasureId],
		[P].[Weight],
		[P].[WeightUnitOfMeasureId],
		[P].[DiscontinuedDate],
		[P].[Picture],
		[B].[BeverageTypeId],
		[B].[BeverageSubtypeId],
		[B].[BeveragePackId],
		[B].[BeverageMiscId],
		[B].[Volume],
		[P].[Comments],
		[P].[Created],
		[P].[CreatedBy],
		[P].[Modified],
		[P].[ModifiedBy],
		[P].[RowVersion]
	from
		[dbo].[Product] as [P] left outer join [dbo].[BeverageData] as [B]
			on ([P].[Id] = [B].[Id])
	where
		[P].[ProductClass] = 3

