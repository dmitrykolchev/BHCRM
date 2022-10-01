create procedure [dbo].[SalesOrderGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'SalesOrder';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[StoragePlaceId],
		[BudgetId],
		[BudgetItemGroupId],
		[BudgetItemId],
		[CustomerId],
		[TotalCost],
		[TotalPrice],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[SalesOrderLineId], [SalesOrderId], [ProductId], [Amount], [Cost], [Price]
		from
			[SalesOrderLine]
		where	
			[SalesOrderId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[SalesOrder] as [SalesOrder]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
