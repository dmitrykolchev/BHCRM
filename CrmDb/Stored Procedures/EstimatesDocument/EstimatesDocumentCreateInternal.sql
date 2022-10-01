create procedure [dbo].[EstimatesDocumentCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('EstimatesDocument') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[EstimatesDocument]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [ServiceRequestId], [VATRateId], [ExtraCostRateId], [Commission], [Margin],
		[Discount], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @ServiceRequestId, @VATRateId, @ExtraCostRateId, @Commission, @Margin, @Discount,
		@Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[EstimatesDocumentSection]
		([EstimatesDocumentId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments])
	select
		@Id,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@ProductCategoryId', 'TIdentifier'),
		T.c.value('@Comments', 'nvarchar(1024)')
	from
		@xml.nodes('EstimatesDocument/Sections/EstimatesDocumentSection') as T(c);

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
	[L] ([ClientId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [UnitOfMeasureId], [Amount], [Price], [CashCost], [NonCashCost]) as 
	(
		select
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

	if @@error <> 0
		return 1;

	return 0;
end
