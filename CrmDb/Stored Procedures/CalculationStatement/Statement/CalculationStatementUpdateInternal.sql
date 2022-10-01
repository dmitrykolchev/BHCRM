create procedure [dbo].[CalculationStatementUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ServiceRequestId TIdentifier,
			@BudgetId TIdentifier,
			@CalculationStage int,
			@IncomeBudgetItemId TIdentifier,
			@ExpenseBudgetItemId TIdentifier,
			@DependsOnAmountOfPersons bit,
			@AmountOnly bit,
			@VATRateId TIdentifier,
			@Margin TPercent,
			@Discount TPercent,
			@ResponsibleEmployeeId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ServiceRequestId = T.c.value('@ServiceRequestId', 'TIdentifier'),
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@CalculationStage = T.c.value('@CalculationStage', 'int'),
		@IncomeBudgetItemId = T.c.value('@IncomeBudgetItemId', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('@ExpenseBudgetItemId', 'TIdentifier'),
		@DependsOnAmountOfPersons = T.c.value('@DependsOnAmountOfPersons', 'bit'),
		@AmountOnly = T.c.value('@AmountOnly', 'bit'),
		@VATRateId = T.c.value('@VATRateId', 'TIdentifier'),
		@Margin = T.c.value('@Margin', 'TPercent'),
		@Discount = T.c.value('@Discount', 'TPercent'),
		@ResponsibleEmployeeId = T.c.value('@ResponsibleEmployeeId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('CalculationStatement') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[CalculationStatement]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[ServiceRequestId] = @ServiceRequestId,
		[BudgetId] = @BudgetId,
		[CalculationStage] = @CalculationStage,
		[IncomeBudgetItemId] = @IncomeBudgetItemId,
		[ExpenseBudgetItemId] = @ExpenseBudgetItemId,
		[DependsOnAmountOfPersons] = @DependsOnAmountOfPersons,
		[AmountOnly] = @AmountOnly,
		[VATRateId] = @VATRateId,
		[Margin] = @Margin,
		[Discount] = @Discount,
		[ResponsibleEmployeeId] = @ResponsibleEmployeeId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	delete from [dbo].[CalculationStatementLine] where [CalculationStatementId] = @Id;
	if @@error <> 0
		return 1;

	delete from [dbo].[CalculationStatementSection] where [CalculationStatementId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[CalculationStatementSection]
		([CalculationStatementId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments], [StandardAmount], [StandardTotalCost], [StandardTotalPrice])
	select
		@Id,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@ProductCategoryId', 'TIdentifier'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		T.c.value('@StandardAmount', 'TAmount'),
		case when @AmountOnly <> 0 then 0 else T.c.value('@StandardTotalCost', 'TMoney') end,
		case when @AmountOnly <> 0 then 0 else T.c.value('@StandardTotalPrice', 'TMoney') end
	from
		@xml.nodes('CalculationStatement/Sections/CalculationStatementSection') as T(c);
	if @@error <> 0
		return 1;

	with [S] ([ClientId], [OrdinalPosition]) as
	(
		select
			T.c.value('@CalculationStatementSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int')
		from
			@xml.nodes('CalculationStatement/Sections/CalculationStatementSection') as T(c)
	),
	[D] ([ServerId], [OrdinalPosition]) as
	(
		select
			[CalculationStatementSectionId],
			[OrdinalPosition]
		from
			[dbo].[CalculationStatementSection]
		where
			[CalculationStatementId] = @Id
	),
	[L] ([ClientId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [StartTime], [EndTime], [AmountPerGuest], [Amount], [Factor], [Price], [Cost]) as 
	(
		select
			T.c.value('@CalculationStatementSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@ProductId', 'TIdentifier'),
			T.c.value('@FileAs', 'nvarchar(1024)'),
			T.c.value('@Comments', 'nvarchar(1024)'),
			T.c.value('@StartTime', 'datetime'),
			T.c.value('@EndTime', 'datetime'),
			T.c.value('@AmountPerGuest', 'TAmount'),
			T.c.value('@Amount', 'TAmount'),
			T.c.value('@Factor', 'TAmount'),
			case when @AmountOnly <> 0 then 0 else T.c.value('@Price', 'TMoney') end,
			case when @AmountOnly <> 0 then 0 else T.c.value('@Cost', 'TMoney') end
		from
			@xml.nodes('CalculationStatement/Lines/CalculationStatementLine') as T(c)
	)
	insert into [dbo].[CalculationStatementLine]
		([CalculationStatementId], [CalculationStatementSectionId], [OrdinalPosition], [ProductId], [FileAs], [Comments], 
		[StartTime], [EndTime], [AmountPerGuest], [Amount], [Factor],	[Price], [Cost])
	select
		@Id,
		[D].[ServerId],
		[L].[OrdinalPosition],
		[L].[ProductId],
		[L].[FileAs],
		[L].[Comments],
		[L].[StartTime],
		[L].[EndTime],
		[L].[AmountPerGuest],
		[L].[Amount],
		[L].[Factor],
		[L].[Price],
		[L].[Cost]
	from	
		[L] inner join [S]	
			on ([L].[ClientId] = [S].[ClientId])
		inner join [D]
			on ([S].[OrdinalPosition] = [D].[OrdinalPosition])

	if @@error <> 0
		return 1;

	declare @result int;
	exec @result = [dbo].[CalculationStatementRecalculate] @Id;
	if @@error <> 0 or @result <> 0
		return 1;

	return 0;
end
