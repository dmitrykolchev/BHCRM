create procedure [dbo].[MasterMenuBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id int, 
			@OrganizationId TIdentifier, @AbstractProductId TIdentifier, @ProductCategoryId TIdentifier, @ProductSubcategoryId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@AbstractProductId = T.c.value('AbstractProductId[1]', 'TIdentifier'),
		@ProductCategoryId = T.c.value('ProductCategoryId[1]', 'TIdentifier'),
		@ProductSubcategoryId = T.c.value('ProductSubcategoryId[1]', 'TIdentifier'),
		@Id = T.c.value('Id[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[OrganizationId],
		[Code],
		[FileAs],
		[FullName],
		[AbstractProductId],
		[ProductTypeId],
		[ProductCategoryId],
		[ProductSubcategoryId],
		[ServiceLevelId],
		[AllowNegativeBalance],
		[CountryId],
		[Manufacturer],
		[ItemColorId],
		[ListPrice],
		[StandardCost],
		[PriceMarginId],
		[UnitOfMeasureId],
		[Size],
		[SizeUnitOfMeasureId],
		[Weight],
		[WeightUnitOfMeasureId],
		[DiscontinuedDate],
		[DishIngredientId],
		[DishTypeId],
		[DishSubtypeId],
		[DishCourseId],
		[DishOccasionId],
		[DishWorldId],
		[DishServingMask],
		[DishCookingMethodId],
		[SeasonMask],
		[ServiceRequestTypeMask],
		[ServingAmount],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[MasterMenu]
	where
		(@Id is null or [Id] = @Id)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId)
	and
		(@AbstractProductId is null or [AbstractProductId] = @AbstractProductId)
	and
		(@ProductCategoryId is null or [ProductCategoryId] = @ProductCategoryId)
	and
		(@ProductSubcategoryId is null or [ProductSubcategoryId] = @ProductSubcategoryId)

	return 0;
end
