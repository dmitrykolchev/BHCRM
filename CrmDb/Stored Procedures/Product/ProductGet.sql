create procedure [dbo].[ProductGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Product';

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
		[RowVersion],
		(select
			[ProductId], [SupplierId]
		from
			[ProductSupplier] 
		where
			[ProductId] = @Id for xml auto, type) as [Suppliers],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Product] as [Product]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
