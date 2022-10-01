create procedure [dbo].[PurchaseInvoiceCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@DueDate date,
			@OrganizationId TIdentifier,
			@AccountId TIdentifier,
			@BudgetId TIdentifier,
			@OperatingBudgetId TIdentifier,
			@BudgetItemGroupId TIdentifier,
			@BudgetItemId TIdentifier,
			@ResponsibleEmployeeId TIdentifier,
			@Subject nvarchar(1024),
			@IsCash bit,
			@Value TMoney,
			@VATRateId TIdentifier,
			@VATValue TMoney,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@DueDate = T.c.value('@DueDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@BudgetId = T.c.value('@BudgetId', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('@OperatingBudgetId', 'TIdentifier'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@ResponsibleEmployeeId = T.c.value('@ResponsibleEmployeeId', 'TIdentifier'),
		@Subject = T.c.value('@Subject', 'nvarchar(1024)'),
		@IsCash = T.c.value('@IsCash', 'bit'),
		@Value = T.c.value('@Value', 'TMoney'),
		@VATRateId = T.c.value('@VATRateId', 'TIdentifier'),
		@VATValue = T.c.value('@VATValue', 'TMoney'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('PurchaseInvoice') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	if @BudgetItemId is not null
		select @BudgetItemGroupId = [BudgetItemGroupId] from [BudgetItem] where [Id] = @BudgetItemId;

	insert into [dbo].[PurchaseInvoice]
		([State], [FileAs], [Number], [DocumentDate], [DueDate], [OrganizationId], [AccountId], [BudgetId], [OperatingBudgetId],
		[BudgetItemGroupId], [BudgetItemId], [ResponsibleEmployeeId], [Subject], [IsCash], [Value], [VATRateId], [VATValue], [Comments], [Created],
		[CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @DueDate, @OrganizationId, @AccountId, @BudgetId, @OperatingBudgetId,
		@BudgetItemGroupId, @BudgetItemId, @ResponsibleEmployeeId, @Subject, @IsCash, @Value, @VATRateId, @VATValue, @Comments, getdate(), @CurrentUserId,
		getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
