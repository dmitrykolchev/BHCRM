create procedure [dbo].[ProductCostStatementGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ProductCostStatement';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select 
			[ProductCostStatementLineId], [ProductCostStatementId], [ProductId], [Cost]
		from 
			[ProductCostStatementLine]
		where
			[ProductCostStatementId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[ProductCostStatement] as [ProductCostStatement]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
