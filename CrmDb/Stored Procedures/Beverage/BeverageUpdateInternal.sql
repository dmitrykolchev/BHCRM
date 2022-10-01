create procedure [dbo].[BeverageUpdateInternal] @xml xml, @Id TIdentifier out
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
			@SupplierId TIdentifier,
			@ItemColorId TIdentifier,
			@UnitOfMeasureId TIdentifier,
			@Size decimal(8,2),
			@SizeUnitOfMeasureId TIdentifier,
			@Weight decimal(8,2),
			@WeightUnitOfMeasureId TIdentifier,
			@DiscontinuedDate date,
			@Picture varbinary(max),
			@BeverageTypeId TIdentifier,
			@BeverageSubtypeId TIdentifier,
			@BeveragePackId TIdentifier,
			@BeverageMiscId TIdentifier,
			@Volume TAmount,
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
		@SupplierId = T.c.value('@SupplierId', 'TIdentifier'),
		@ItemColorId = T.c.value('@ItemColorId', 'TIdentifier'),
		@UnitOfMeasureId = T.c.value('@UnitOfMeasureId', 'TIdentifier'),
		@Size = T.c.value('@Size', 'decimal(8,2)'),
		@SizeUnitOfMeasureId = T.c.value('@SizeUnitOfMeasureId', 'TIdentifier'),
		@Weight = T.c.value('@Weight', 'decimal(8,2)'),
		@WeightUnitOfMeasureId = T.c.value('@WeightUnitOfMeasureId', 'TIdentifier'),
		@DiscontinuedDate = T.c.value('@DiscontinuedDate', 'date'),
		@Picture = T.c.value('@Picture', 'varbinary(max)'),
		@BeverageTypeId = T.c.value('@BeverageTypeId', 'TIdentifier'),
		@BeverageSubtypeId = T.c.value('@BeverageSubtypeId', 'TIdentifier'),
		@BeveragePackId = T.c.value('@BeveragePackId', 'TIdentifier'),
		@BeverageMiscId = T.c.value('@BeverageMiscId', 'TIdentifier'),
		@Volume = T.c.value('@Volume', 'TAmount'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Beverage') as T(c);
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
		[SupplierId] = @SupplierId,
		[ItemColorId] = @ItemColorId,
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

	if exists(select * from [dbo].[BeverageData] where [Id] = @Id)
	begin
		update [dbo].[BeverageData]
		set
			[BeverageTypeId] = @BeverageTypeId,
			[BeverageSubtypeId] = @BeverageSubtypeId,
			[BeveragePackId] = @BeveragePackId,
			[BeverageMiscId] = @BeverageMiscId,
			[Volume] = @Volume
		where
			[Id] = @Id;

		if @@error <> 0
			return 1;
	end
	else
	begin
		insert into [dbo].[BeverageData]
			([Id], [BeverageTypeId], [BeverageSubtypeId], [BeveragePackId], [BeverageMiscId], [Volume])
		values
			(@Id, @BeverageTypeId, @BeverageSubtypeId, @BeveragePackId, @BeverageMiscId, @Volume);

		if @@error <> 0
			return 1;
	end

	return 0;
end
