create function [dbo].[EstimatesDocumentGetFn](@Id TIdentifier)
returns xml
as
begin
	declare @DocumentTypeId int;

	select @DocumentTypeId = [dbo].[GetDocumentTypeId]('EstimatesDocument');

	return (select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[ServiceRequestId],
		[VATRateId],
		[ExtraCostRateId],
		[Commission],
		[Margin],
		[Discount],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[EstimatesDocumentSectionId], [EstimatesDocumentId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments]
		from
			[dbo].[EstimatesDocumentSection] as [EstimatesDocumentSection]
		where
			[EstimatesDocumentId] = @Id
		order by
			[OrdinalPosition]
		for xml auto, type) as [Sections],
		(select 
			[EstimatesDocumentLineId], [EstimatesDocumentSectionId], [EstimatesDocumentId], [ProductId], [FileAs], [Comments], [UnitOfMeasureId], [Amount], [Price], [CashCost], [NonCashCost]
		from
			[dbo].[EstimatesDocumentLine] as [EstimatesDocumentLine]
		where
			[EstimatesDocumentId] = @Id
		order by
			[OrdinalPosition]
		for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[EstimatesDocument] as [EstimatesDocument]
	where
		[Id] = @Id
		for xml auto, binary base64);
end