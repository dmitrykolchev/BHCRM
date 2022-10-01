create procedure [dbo].[CalculationStatementTemplateUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@BudgetTemplateId TIdentifier,
			@IncomeBudgetItemId TIdentifier,
			@ExpenseBudgetItemId TIdentifier,
			@DependsOnAmountOfPersons bit,
			@AmountOnly bit,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BudgetTemplateId = T.c.value('@BudgetTemplateId', 'TIdentifier'),
		@IncomeBudgetItemId = T.c.value('@IncomeBudgetItemId', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('@ExpenseBudgetItemId', 'TIdentifier'),
		@DependsOnAmountOfPersons = T.c.value('@DependsOnAmountOfPersons', 'bit'),
		@AmountOnly = T.c.value('@AmountOnly', 'bit'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('CalculationStatementTemplate') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[CalculationStatementTemplate]
	set
		[FileAs] = @FileAs,
		[BudgetTemplateId] = @BudgetTemplateId,
		[IncomeBudgetItemId] = @IncomeBudgetItemId,
		[ExpenseBudgetItemId] = @ExpenseBudgetItemId,
		[DependsOnAmountOfPersons] = @DependsOnAmountOfPersons,
		[AmountOnly] = @AmountOnly,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	-- remove deleted records
	delete [dbo].[CalculationStatementTemplateLine] 
	where
		[CalculationStatementTemplateId] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[CalculationStatementTemplateSection]
	where
		[CalculationStatementTemplateId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[CalculationStatementTemplateSection]
		([CalculationStatementTemplateId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments])
	select
		@Id,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@ProductCategoryId', 'TIdentifier'),
		T.c.value('@Comments', 'nvarchar(1024)')
	from
		@xml.nodes('CalculationStatementTemplate/Sections/CalculationStatementTemplateSection') as T(c);
	if @@error <> 0
		return 1;

	with [S] ([ClientId], [OrdinalPosition]) as
	(
		select
			T.c.value('@CalculationStatementTemplateSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int')
		from
			@xml.nodes('CalculationStatementTemplate/Sections/CalculationStatementTemplateSection') as T(c)
	),
	[D] ([ServerId], [OrdinalPosition]) as
	(
		select
			[CalculationStatementTemplateSectionId],
			[OrdinalPosition]
		from
			[dbo].[CalculationStatementTemplateSection]
		where
			[CalculationStatementTemplateId] = @Id
	),
	[L] ([ClientId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [Duration], [Amount], [DependsOnAmountOfPersons], [DependsOnEventDuration], [Price], [Cost]) as 
	(
		select
			T.c.value('@CalculationStatementTemplateSectionId', 'TIdentifier'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@ProductId', 'TIdentifier'),
			T.c.value('@FileAs', 'nvarchar(1024)'),
			T.c.value('@Comments', 'nvarchar(1024)'),
			T.c.value('@Duration', 'TAmount'),
			T.c.value('@Amount', 'TAmount'),
			T.c.value('@DependsOnAmountOfPersons', 'bit'),
			T.c.value('@DependsOnEventDuration', 'bit'),
			case when @AmountOnly <> 0 then 0 else T.c.value('@Price', 'TMoney') end,
			case when @AmountOnly <> 0 then 0 else T.c.value('@Cost', 'TMoney') end
		from
			@xml.nodes('CalculationStatementTemplate/Lines/CalculationStatementTemplateLine') as T(c)
	)
	insert into [dbo].[CalculationStatementTemplateLine]
		([CalculationStatementTemplateId], [CalculationStatementTemplateSectionId], [OrdinalPosition], [ProductId], [FileAs], [Comments], [Duration], [Amount],
		[DependsOnAmountOfPersons], [DependsOnEventDuration], [Price], [Cost])
	select
		@Id,
		[D].[ServerId],
		[L].[OrdinalPosition],
		[L].[ProductId],
		[L].[FileAs],
		[L].[Comments],
		[L].[Duration],
		[L].[Amount],
		[L].[DependsOnAmountOfPersons],
		[L].[DependsOnEventDuration],
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
	exec @result = [dbo].[BudgetTemplateRecalculate] @BudgetTemplateId;
	if @@error<> 0 or @result <> 0
		return 1;

	return 0;
end
