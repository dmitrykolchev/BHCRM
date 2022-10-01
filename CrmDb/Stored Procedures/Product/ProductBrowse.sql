create procedure [dbo].[ProductBrowse] @filter xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @Presentation varchar(256);
	declare @AbstractProductId TIdentifier, @OrganizationId TIdentifier, @ProductCategoryId TIdentifier, @ProductSubcategoryId TIdentifier, 
			@ServiceLevelId TIdentifier, @SupplierId TIdentifier, @ProductTypeId TIdentifier, @AllStates bit, @BudgetItemId TIdentifier;

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
		@BudgetItemId = T.c.value('BudgetItemId[1]', 'TIdentifier')
	from
		@filter.nodes('Filter') as T(c);

	if @Presentation = 'ServiceCost'
		set @ProductTypeId = 2;

	select
		[Id],
		[State],
		[OrganizationId],
		[ProductClass],
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
		[SupplierId],
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
		[Picture],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Product]
	where
		(@Id is null or [Id] = @Id)
	and
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
		(@ServiceLevelId is null or ([ServiceLevelId] & @ServiceLevelId) <> 0)
	and
		(@BudgetItemId is null or [ProductCategoryId] in (select [ProductCategoryId] from [BudgetItemProductCategory] where [BudgetItemId] = @BudgetItemId));

	return 0;
end
