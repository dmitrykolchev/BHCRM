create procedure [dbo].[ReturnStatementGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int, @SalesOrderId TIdentifier;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ReturnStatement';

	select @SalesOrderId = [SalesOrderId] from [ReturnStatement] where [Id] = @Id;

	declare @Line table ([ReturnStatementLineId] int null, [ReturnStatementId] int not null, [ProductId] int not null, [PurchasedAmount] TAmount, [Amount] TAmount, [Cost] TMoney, [Price] TMoney);

	insert @Line 
		([ReturnStatementLineId], [ReturnStatementId], [ProductId], [PurchasedAmount], [Amount], [Cost], [Price])
	select
		[ReturnStatementLine].[ReturnStatementLineId],
		@Id,
		[SalesOrderLine].[ProductId],
		[SalesOrderLine].[Amount],
		isnull([ReturnStatementLine].[Amount], 0),
		[SalesOrderLine].[Cost],
		[SalesOrderLine].[Price]
	from
		[SalesOrderLine] left outer join [ReturnStatementLine]
			on ([SalesOrderLine].[ProductId] = [ReturnStatementLine].[ProductId])
	where
		[SalesOrderLine].[SalesOrderId] = @SalesOrderId and [ReturnStatementLine].[ReturnStatementId] = @Id;

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[StoragePlaceId],
		[SalesOrderId],
		[TotalCost],
		[TotalPrice],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[ReturnStatementLineId], [ReturnStatementId], [ProductId], [PurchasedAmount], [Amount], [Cost], [Price]
		from
			@Line as [ReturnStatementLine]
		for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[ReturnStatement] as [ReturnStatement]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
