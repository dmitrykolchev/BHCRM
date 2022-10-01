create procedure [dbo].[MasterMenuGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'MasterMenu';

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
		[Picture],
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
		[RowVersion],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[MasterMenu] as [MasterMenu]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
