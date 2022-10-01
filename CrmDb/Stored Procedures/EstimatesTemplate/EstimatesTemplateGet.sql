create procedure [dbo].[EstimatesTemplateGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'EstimatesTemplate';

	select
		[Id],
		[State],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[EstimatesTemplateSectionId],[EstimatesTemplateId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments]
		from 
			[EstimatesTemplateSection]
		where
			[EstimatesTemplateId] = @Id
		order by
			[OrdinalPosition]
		for xml auto, type) as [Sections],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[EstimatesTemplate] as [EstimatesTemplate]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
