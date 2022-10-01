CREATE PROCEDURE [dbo].[ConsolidatedInventoryOperationBrowse] @filter xml
AS
begin
	set nocount on;

	declare @PeriodStart date, @PeriodEnd date, @OrganizationId TIdentifier, @StoragePlaceId TIdentifier;

	select
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@StoragePlaceId = T.c.value('StoragePlaceId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

	declare @SalesOrderType int = [dbo].[GetDocumentTypeId]('SalesOrder'),
			@PurchaseOrderType int = [dbo].[GetDocumentTypeId]('PurchaseOrder'),
			@ReturnStatementType int = [dbo].[GetDocumentTypeId]('ReturnStatement'),
			@WriteoffStatementType int =[dbo].[GetDocumentTypeId]('WriteoffStatement');

	with [Purchase] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([IncomingAmount]),
			sum([IncomingAmount] * [Cost])
		from
			[InventoryOperation]
		where
			[OperationDate] >= @PeriodStart and [OperationDate] <= @PeriodEnd
		and
			[DocumentTypeId] = @PurchaseOrderType
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId]
	),
	[Sales] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([OutgoingAmount]),
			sum([OutgoingAmount] * [Cost])
		from
			[InventoryOperation]
		where
			[OperationDate] >= @PeriodStart and [OperationDate] <= @PeriodEnd
		and
			[DocumentTypeId] = @SalesOrderType
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId]
	),
	[Writeoff] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([OutgoingAmount]),
			sum([OutgoingAmount] * [Cost])
		from
			[InventoryOperation]
		where
			[OperationDate] >= @PeriodStart and [OperationDate] <= @PeriodEnd
		and
			[DocumentTypeId] = @WriteoffStatementType
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId]
	),
	[Returns] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([IncomingAmount]),
			sum([IncomingAmount] * [Cost])
		from
			[InventoryOperation]
		where
			[OperationDate] >= @PeriodStart and [OperationDate] <= @PeriodEnd
		and
			[DocumentTypeId] = @ReturnStatementType
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId]
	), 
	[Start] ([ProductId], [Amount], [TotalCost]) as
	(
		select
			[ProductId],
			sum([IncomingAmount] - [OutgoingAmount]),
			sum(([IncomingAmount] - [OutgoingAmount]) * [Cost])
		from
			[InventoryOperation]
		where
			[OperationDate] < @PeriodStart
		and
			(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
			(@StoragePlaceId is null or [StoragePlaceId] = @StoragePlaceId)
		group by
			[ProductId]
	),
	[ConsolidatedInventoryOperationLine] ([ProductId], 
		[StartAmount], [StartCost],
		[PurchaseAmount], [PurchaseCost], 
		[SalesAmount], [SalesCost], 
		[WriteoffAmount], [WriteoffCost], 
		[ReturnsAmount], [ReturnsCost]) as
	(
	select
		[Product].[Id],
		[Start].[Amount],
		[Start].[TotalCost],
		[Purchase].[Amount],
		[Purchase].[TotalCost],
		[Sales].[Amount],
		[Sales].[TotalCost],
		[Writeoff].[Amount],
		[Writeoff].[TotalCost],
		[Returns].[Amount],
		[Returns].[TotalCost]
	from
		[Product] left outer join [Start]
			on ([Product].[Id] = [Start].[ProductId])
		left outer join [Purchase]
			on ([Product].[Id] = [Purchase].[ProductId])
		left outer join [Sales]
			on ([Product].[Id] = [Sales].[ProductId])
		left outer join [Returns]
			on ([Product].[Id] = [Returns].[ProductId])
		left outer join [Writeoff]
			on ([Product].[Id] = [Writeoff].[ProductId])
	where
		[Start].[Amount] is not null or [Purchase].[Amount] is not null or [Sales].[Amount] is not null or [Writeoff].[Amount] is not null or [Returns].[Amount] is not null
	)
	select
		[ConsolidatedInventoryOperationLine].[ProductId],
		[Product].[ProductCategoryId],
		[Product].[ProductSubcategoryId],
		[Product].[ProductTypeId],
		[Product].[ProductClass],
		[ConsolidatedInventoryOperationLine].[StartAmount],
		[ConsolidatedInventoryOperationLine].[StartCost],
		[ConsolidatedInventoryOperationLine].[PurchaseAmount],
		[ConsolidatedInventoryOperationLine].[PurchaseCost],
		[ConsolidatedInventoryOperationLine].[SalesAmount],
		[ConsolidatedInventoryOperationLine].[SalesCost],
		[ConsolidatedInventoryOperationLine].[WriteoffAmount],
		[ConsolidatedInventoryOperationLine].[WriteoffCost],
		[ConsolidatedInventoryOperationLine].[ReturnsAmount],
		[ConsolidatedInventoryOperationLine].[ReturnsCost]
	from
		[ConsolidatedInventoryOperationLine] inner join [Product]
			on ([ConsolidatedInventoryOperationLine].[ProductId] = [Product].[Id])
	for xml raw('ConsolidatedInventoryOperationLine'), root('ArrayOfConsolidatedInventoryOperationLine');	

	return 0;
end

grant execute on [dbo].[ConsolidatedInventoryOperationBrowse] to [public];
go
