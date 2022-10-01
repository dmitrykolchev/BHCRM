create procedure [dbo].[BeverageGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Beverage';

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
		[SupplierId],
		[ItemColorId],
		[ListPrice],
		[StandardCost],
		[UnitOfMeasureId],
		[Size],
		[SizeUnitOfMeasureId],
		[Weight],
		[WeightUnitOfMeasureId],
		[DiscontinuedDate],
		[Picture],
		[BeverageTypeId],
		[BeverageSubtypeId],
		[BeveragePackId],
		[BeverageMiscId],
		[Volume],
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
		[dbo].[Beverage] as [Beverage]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
