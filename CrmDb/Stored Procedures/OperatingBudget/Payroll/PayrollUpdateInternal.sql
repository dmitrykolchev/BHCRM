create procedure [dbo].[PayrollUpdateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Payroll') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Payroll]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[OperatingBudgetId] = @OperatingBudgetId,
		[SalaryBudgetItemId] = @SalaryBudgetItemId,
		[TaxBudgetItemId] = @TaxBudgetItemId,
		[CashingBudgetItemId] = @CashingBudgetItemId,
		[ExtraCostRateId] = @ExtraCostRateId,
		[CalculationStage] = @CalculationStage,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	declare @DocumentTypeId TIdentifier = [dbo].[GetDocumentTypeId]('Payroll');

	delete [dbo].[OperatingBudgetLine] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
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
