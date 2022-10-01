create procedure [dbo].[OperatingCalculationCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@OperatingBudgetId TIdentifier,
			@BudgetItemId TIdentifier,
			@CalculationStage int,
			@TotalValue TMoney,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('@OperatingBudgetId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@CalculationStage = T.c.value('@CalculationStage', 'int'),
		@TotalValue = T.c.value('@TotalValue', 'TMoney'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('OperatingCalculation') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[OperatingCalculation]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [OperatingBudgetId], [BudgetItemId],
		[CalculationStage], [TotalValue], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @OperatingBudgetId, @BudgetItemId,
		@CalculationStage, @TotalValue, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	declare @DocumentTypeId int;
	
	set @DocumentTypeId = dbo.GetDocumentTypeId('OperatingCalculation');

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@BudgetItemId,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		T.c.value('@Amount', 'TAmount'),
		T.c.value('@Price', 'TMoney')
	from
		@xml.nodes('OperatingCalculation/Lines/OperatingCalculationLine') as T(c);
	if @@error <> 0
		return 1;

	update [dbo].[OperatingCalculation]
	set
		[TotalValue] = (select sum([Amount] * [Price]) from [OperatingBudgetLine] where [DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId)
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	return 0;
end
