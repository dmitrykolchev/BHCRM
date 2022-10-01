create procedure [dbo].[EstimatesDocumentUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ServiceRequestId TIdentifier,
			@VATRateId TIdentifier,
			@ExtraCostRateId TIdentifier,
			@Commission TPercent,
			@Margin TPercent,
			@Discount TPercent,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ServiceRequestId = T.c.value('@ServiceRequestId', 'TIdentifier'),
		@VATRateId = T.c.value('@VATRateId', 'TIdentifier'),
		@ExtraCostRateId = T.c.value('@ExtraCostRateId', 'TIdentifier'),
		@Commission = T.c.value('@Commission', 'TPercent'),
		@Margin = T.c.value('@Margin', 'TPercent'),
		@Discount = T.c.value('@Discount', 'TPercent'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('EstimatesDocument') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[EstimatesDocumentGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'EstimatesDocument', @Id, null, @LogData, null;
	if @@error <> 0 or @result <> 0
		return 1;
	-- end log document state entry	

	update [dbo].[EstimatesDocument]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[ServiceRequestId] = @ServiceRequestId,
		[VATRateId] = @VATRateId,
		[ExtraCostRateId] = @ExtraCostRateId,
		[Commission] = @Commission,
		[Margin] = @Margin,
		[Discount] = @Discount,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	-- remove deleted records
	delete [dbo].[EstimatesDocumentLine] 
	where
		[EstimatesDocumentId] = @Id and
		[EstimatesDocumentLineId] not in (
			select T.c.value('@EstimatesDocumentLineId', 'TIdentifier') 
			from @xml.nodes('EstimatesDocument/Lines/EstimatesDocumentLine') as T(c));
	if @@error <> 0
		return 1;

	delete [dbo].[EstimatesDocumentSection]
	where
		[EstimatesDocumentId] = @Id and
		[EstimatesDocumentSectionId] not in (
		select T.c.value('@EstimatesDocumentSectionId', 'TIdentifier') 
		from @xml.nodes('EstimatesDocument/Sections/EstimatesDocumentSection') as T(c));
	if @@error <> 0
		return 1;

	-- update existing items

	with [S] ([EstimatesDocumentSectionId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments]) as
	(
		select
			T.c.value('@EstimatesDocumentSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@FileAs', 'TName'),
			T.c.value('@ProductCategoryId', 'TIdentifier'),
			T.c.value('@Comments', 'nvarchar(1024)')
		from
			@xml.nodes('EstimatesDocument/Sections/EstimatesDocumentSection') as T(c)
	)
	update [dbo].[EstimatesDocumentSection]
	set
		[OrdinalPosition] = [S].[OrdinalPosition],
		[FileAs] = [S].[FileAs],
		[ProductCategoryId] = [S].[ProductCategoryId],
		[Comments] = [S].[Comments]
	from
		[dbo].[EstimatesDocumentSection] inner join [S]
			on ([EstimatesDocumentSection].[EstimatesDocumentSectionId] = [S].[EstimatesDocumentSectionId])
	if @@error <> 0
		return 1;

	with [L] ([EstimatesDocumentLineId], [EstimatesDocumentSectionId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [UnitOfMeasureId], [Amount], [Price], [CashCost], [NonCashCost]) as
	(
		select
			T.c.value('@EstimatesDocumentLineId', 'TIdentifier'),
			T.c.value('@EstimatesDocumentSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@ProductId', 'TIdentifier'),
			T.c.value('@FileAs', 'nvarchar(1024)'),
			T.c.value('@Comments', 'nvarchar(1024)'),
			T.c.value('@UnitOfMeasureId', 'TIdentifier'),
			T.c.value('@Amount', 'TAmount'),
			T.c.value('@Price', 'TMoney'),
			T.c.value('@CashCost', 'TMoney'),
			T.c.value('@NonCashCost', 'TMoney')
		from
			@xml.nodes('EstimatesDocument/Lines/EstimatesDocumentLine') as T(c)
	)
	update [dbo].[EstimatesDocumentLine]
	set
		[OrdinalPosition] = [L].[OrdinalPosition],
		[ProductId] = [L].[ProductId],
		[FileAs] = [L].[FileAs],
		[Comments] = [L].[Comments],
		[UnitOfMeasureId] = [L].[UnitOfMeasureId],
		[Amount] = [L].[Amount],
		[Price] = [L].[Price],
		[CashCost] = [L].[CashCost],
		[NonCashCost] = [L].[NonCashCost]
	from
		[dbo].[EstimatesDocumentLine] inner join [L]	
			on ([EstimatesDocumentLine].[EstimatesDocumentLineId] = [L].[EstimatesDocumentLineId] and [L].[EstimatesDocumentLineId] != 0)
	if @@error <> 0
		return 1;

	-- insert new items

	insert into [dbo].[EstimatesDocumentSection]
		([EstimatesDocumentId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments])
	select
		@Id,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@ProductCategoryId', 'TIdentifier'),
		T.c.value('@Comments', 'nvarchar(1024)')
	from
		@xml.nodes('EstimatesDocument/Sections/EstimatesDocumentSection') as T(c)
	where
		T.c.value('@EstimatesDocumentSectionId', 'TIdentifier') < 0;

	if @@error <> 0
		return 1;

	with [S] ([ClientId], [OrdinalPosition]) as
	(
		select
			T.c.value('@EstimatesDocumentSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int')
		from
			@xml.nodes('EstimatesDocument/Sections/EstimatesDocumentSection') as T(c)
	),
	[D] ([ServerId], [OrdinalPosition]) as
	(
		select
			[EstimatesDocumentSectionId],
			[OrdinalPosition]
		from
			[dbo].[EstimatesDocumentSection]
		where
			[EstimatesDocumentId] = @Id
	),
	[L] ([EstimatesDocumentLineId], [ClientId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [UnitOfMeasureId], [Amount], [Price], [CashCost], [NonCashCost]) as 
	(
		select
			T.c.value('@EstimatesDocumentLineId', 'TIdentifier'),
			T.c.value('@EstimatesDocumentSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@ProductId', 'TIdentifier'),
			T.c.value('@FileAs', 'nvarchar(1024)'),
			T.c.value('@Comments', 'nvarchar(1024)'),
			T.c.value('@UnitOfMeasureId', 'TIdentifier'),
			T.c.value('@Amount', 'TAmount'),
			T.c.value('@Price', 'TMoney'),
			T.c.value('@CashCost', 'TMoney'),
			T.c.value('@NonCashCost', 'TMoney')
		from
			@xml.nodes('EstimatesDocument/Lines/EstimatesDocumentLine') as T(c)
		where
			T.c.value('@EstimatesDocumentLineId', 'TIdentifier') = 0
	)
	insert into [dbo].[EstimatesDocumentLine]
		([EstimatesDocumentId], [EstimatesDocumentSectionId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [UnitOfMeasureId], [Amount], [Price], [CashCost], [NonCashCost])
	select
		@Id,
		[D].[ServerId],
		[L].[OrdinalPosition],
		[L].[ProductId],
		[L].[FileAs],
		[L].[Comments],
		[L].[UnitOfMeasureId],
		[L].[Amount],
		[L].[Price],
		[L].[CashCost],
		[L].[NonCashCost]
	from	
		[L] inner join [S]	
			on ([L].[ClientId] = [S].[ClientId])
		inner join [D]
			on ([S].[OrdinalPosition] = [D].[OrdinalPosition])
	where
		[L].[EstimatesDocumentLineId] = 0;

	if @@error <> 0
		return 1;

	return 0;
end
