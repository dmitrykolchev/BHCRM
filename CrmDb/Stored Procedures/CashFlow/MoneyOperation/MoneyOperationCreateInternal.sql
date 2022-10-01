create procedure [dbo].[MoneyOperationCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('MoneyOperation') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[MoneyOperation]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [ParentId], [BankAccountId],
		[MoneyOperationTypeId], [MoneyOperationDirection], [BudgetId], [OperatingBudgetId], [BudgetItemGroupId], [BudgetItemId],
		[SalesInvoiceId], [PurchaseInvoiceId], [AccountId], [EmployeeId], [Subject], [Value], [VATRateId], [VATValue],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @ParentId, @BankAccountId, @MoneyOperationTypeId, @MoneyOperationDirection,
		@BudgetId, @OperatingBudgetId, @BudgetItemGroupId, @BudgetItemId, @SalesInvoiceId, @PurchaseInvoiceId,
		@AccountId, @EmployeeId, @Subject, @Value, @VATRateId, @VATValue, @Comments, getdate(), @CurrentUserId,
		getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();
	if @MoneyOperationTypeId = 5
	begin
		insert into [dbo].[MoneyOperation]
			([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [ParentId], [BankAccountId], 
			[MoneyOperationTypeId], [MoneyOperationDirection], [BudgetId], [OperatingBudgetId], [BudgetItemGroupId], [BudgetItemId],
			[SalesInvoiceId], [PurchaseInvoiceId], [AccountId], [EmployeeId], [Subject], [Value], [VATRateId], [VATValue],
			[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @Id, @DestinationBankAccountId, @MoneyOperationTypeId, 1,
			@BudgetId, @OperatingBudgetId, @BudgetItemGroupId, @BudgetItemId, @SalesInvoiceId, @PurchaseInvoiceId,
			@AccountId, @EmployeeId, @Subject, @Value, @VATRateId, @VATValue, @Comments, getdate(), @CurrentUserId,
			getdate(), @CurrentUserId);

		if @@error <> 0
			return 1;
	end

	return 0;
end
