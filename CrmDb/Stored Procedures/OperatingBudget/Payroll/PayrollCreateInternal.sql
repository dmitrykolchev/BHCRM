create procedure [dbo].[PayrollCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@OperatingBudgetId TIdentifier,
			@SalaryBudgetItemId TIdentifier,
			@TaxBudgetItemId TIdentifier,
			@CashingBudgetItemId TIdentifier,
			@ExtraCostRateId TIdentifier,
			@CalculationStage int,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('@OperatingBudgetId', 'TIdentifier'),
		@SalaryBudgetItemId = T.c.value('@SalaryBudgetItemId', 'TIdentifier'),
		@TaxBudgetItemId = T.c.value('@TaxBudgetItemId', 'TIdentifier'),
		@CashingBudgetItemId = T.c.value('@CashingBudgetItemId', 'TIdentifier'),
		@ExtraCostRateId = T.c.value('@ExtraCostRateId', 'TIdentifier'),
		@CalculationStage = T.c.value('@CalculationStage', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Payroll') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Payroll]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [OperatingBudgetId], [SalaryBudgetItemId], [TaxBudgetItemId], [CashingBudgetItemId], [ExtraCostRateId],
		[CalculationStage], [Comments], [Created], [CreatedBy],	[Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @OperatingBudgetId, @SalaryBudgetItemId, @TaxBudgetItemId, @CashingBudgetItemId, @ExtraCostRateId,
		@CalculationStage, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	declare @DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('Payroll');

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@SalaryBudgetItemId,
		1,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		1,
		T.c.value('@SalaryTotal', 'TMoney') - T.c.value('@SalaryBase', 'TMoney')
	from
		@xml.nodes('Payroll/Lines/PayrollLine') as T(c);
	if @@error <> 0
		return 1;

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@SalaryBudgetItemId,
		2,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		1,
		T.c.value('@SalaryBase', 'TMoney')
	from
		@xml.nodes('Payroll/Lines/PayrollLine') as T(c);
	if @@error <> 0
		return 1;

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@TaxBudgetItemId,
		3,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		1,
		T.c.value('@IncomeTax', 'TMoney')
	from
		@xml.nodes('Payroll/Lines/PayrollLine') as T(c);
	if @@error <> 0
		return 1;

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@TaxBudgetItemId,
		4,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		1,
		T.c.value('@SocialTax', 'TMoney')
	from
		@xml.nodes('Payroll/Lines/PayrollLine') as T(c);
	if @@error <> 0
		return 1;

	insert into [dbo].[OperatingBudgetLine]
		([OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price])
	select
		@OperatingBudgetId,
		@CalculationStage,
		@DocumentTypeId,
		@Id,
		@CashingBudgetItemId,
		5,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@AccountId', 'TIdentifier'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@Comments', 'nvarchar(1024)'),
		1,
		T.c.value('@Cashing', 'TMoney')
	from
		@xml.nodes('Payroll/Lines/PayrollLine') as T(c);
	if @@error <> 0
		return 1;

	return 0;
end
