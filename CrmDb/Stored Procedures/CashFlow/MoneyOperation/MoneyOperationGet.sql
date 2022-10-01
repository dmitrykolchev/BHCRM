create procedure [dbo].[MoneyOperationGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'MoneyOperation';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[ParentId],
		[BankAccountId],
		(case when [MoneyOperationTypeId] = 5 then (select [BankAccountId] from [MoneyOperation] where [ParentId] = @Id) else null end) as [DestinationBankAccountId],
		[MoneyOperationTypeId],
		[MoneyOperationDirection],
		[BudgetId],
		[OperatingBudgetId],
		[BudgetItemGroupId],
		[BudgetItemId],
		[SalesInvoiceId],
		[PurchaseInvoiceId],
		[AccountId],
		[EmployeeId],
		[Subject],
		[Value],
		[VATRateId],
		[VATValue],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[MoneyOperation] as [MoneyOperation]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
