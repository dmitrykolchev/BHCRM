create procedure [dbo].[MoneyOperationUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ParentId TIdentifier,
			@BankAccountId TIdentifier,
			@DestinationBankAccountId TIdentifier,
			@MoneyOperationTypeId TIdentifier,
			@MoneyOperationDirection int,
			@BudgetId TIdentifier,
			@OperatingBudgetId TIdentifier,
			@BudgetItemGroupId TIdentifier,
			@BudgetItemId TIdentifier,
			@SalesInvoiceId TIdentifier,
			@PurchaseInvoiceId TIdentifier,
			@AccountId TIdentifier,
			@EmployeeId TIdentifier,
			@Subject nvarchar(1024),
			@Value TMoney,
			@VATRateId TIdentifier,
			@VATValue TMoney,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ParentId = T.c.value('@ParentId', 'TIdentifier'),
		@BankAccountId = T.c.value('@BankAccountId', 'TIdentifier'),
		@DestinationBankAccountId = T.c.value('@DestinationBankAccountId', 'TIdentifier'),
		@MoneyOperationTypeId = T.c.value('@MoneyOperationTypeId', 'TIdentifier'),
		@MoneyOperationDirection = T.c.value('@MoneyOperationDirection', 'int'),
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('@OperatingBudgetId', 'TIdentifier'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@SalesInvoiceId = T.c.value('@SalesInvoiceId', 'TIdentifier'),
		@PurchaseInvoiceId = T.c.value('@PurchaseInvoiceId', 'TIdentifier'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@EmployeeId = T.c.value('@EmployeeId', 'TIdentifier'),
		@Subject = T.c.value('@Subject', 'nvarchar(1024)'),
		@Value = T.c.value('@Value', 'TMoney'),
		@VATRateId = T.c.value('@VATRateId', 'TIdentifier'),
		@VATValue = T.c.value('@VATValue', 'TMoney'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('MoneyOperation') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[MoneyOperation]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[ParentId] = @ParentId,
		[BankAccountId] = @BankAccountId,
		[MoneyOperationTypeId] = @MoneyOperationTypeId,
		[MoneyOperationDirection] = @MoneyOperationDirection,
		[BudgetId] = @BudgetId,
		[OperatingBudgetId] = @OperatingBudgetId,
		[BudgetItemGroupId] = @BudgetItemGroupId,
		[BudgetItemId] = @BudgetItemId,
		[SalesInvoiceId] = @SalesInvoiceId,
		[PurchaseInvoiceId] = @PurchaseInvoiceId,
		[AccountId] = @AccountId,
		[EmployeeId] = @EmployeeId,
		[Subject] = @Subject,
		[Value] = @Value,
		[VATRateId] = @VATRateId,
		[VATValue] = @VATValue,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;
	if @MoneyOperationTypeId = 5
	begin
		update [dbo].[MoneyOperation]
		set
			[FileAs] = @FileAs,
			[Number] = @Number,
			[DocumentDate] = @DocumentDate,
			[OrganizationId] = @OrganizationId,
			[ParentId] = @Id,
			[BankAccountId] = @DestinationBankAccountId,
			[MoneyOperationTypeId] = @MoneyOperationTypeId,
			[MoneyOperationDirection] = 1,
			[BudgetId] = @BudgetId,
			[OperatingBudgetId] = @OperatingBudgetId,
			[BudgetItemGroupId] = @BudgetItemGroupId,
			[BudgetItemId] = @BudgetItemId,
			[SalesInvoiceId] = @SalesInvoiceId,
			[PurchaseInvoiceId] = @PurchaseInvoiceId,
			[AccountId] = @AccountId,
			[EmployeeId] = @EmployeeId,
			[Subject] = @Subject,
			[Value] = @Value,
			[VATRateId] = @VATRateId,
			[VATValue] = @VATValue,
			[Comments] = @Comments,
			[Modified] = getdate(),
			[ModifiedBy] = @CurrentUserId
		where
			[ParentId] = @Id;

		if @@error <> 0
			return 1;
	end

	return 0;
end
