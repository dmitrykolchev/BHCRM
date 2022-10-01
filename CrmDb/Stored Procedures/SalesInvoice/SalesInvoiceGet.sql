create procedure [dbo].[SalesInvoiceGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'SalesInvoice';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[DueDate],
		[OrganizationId],
		[AccountId],
		[BudgetId],
		[OperatingBudgetId],
		[BudgetItemGroupId],
		[BudgetItemId],
		[ResponsibleEmployeeId],
		[Subject],
		[IsCash],
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
		[dbo].[SalesInvoice] as [SalesInvoice]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
