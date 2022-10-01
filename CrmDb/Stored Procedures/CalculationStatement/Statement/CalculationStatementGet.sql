create procedure [dbo].[CalculationStatementGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'CalculationStatement';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[ServiceRequestId],
		[BudgetId],
		[CalculationStage],
		[IncomeBudgetItemId],
		[ExpenseBudgetItemId],
		[DependsOnAmountOfPersons],
		[AmountOnly],
		[VATRateId],
		[Margin],
		[Discount],
		[ResponsibleEmployeeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[CalculationStatementSectionId],
			[CalculationStatementId],
			[OrdinalPosition],
			[FileAs],
			[ProductCategoryId],
			[Comments],
			[StandardAmount],
			[StandardTotalCost],
			[StandardTotalPrice]
		from 
			[CalculationStatementSection]
		where	
			[CalculationStatementId] = @Id for xml auto, type) as [Sections],
		(select
			[CalculationStatementLineId], 
			[CalculationStatementSectionId], 
			[CalculationStatementId], 
			[OrdinalPosition], 
			[ProductId], 
			[FileAs], 
			[Comments], 
			[StartTime], 
			[EndTime], 
			[AmountPerGuest],
			[Amount], 
			[Factor], 
			[Price], 
			[Cost]
		from
			[CalculationStatementLine]
		where
			[CalculationStatementId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[CalculationStatement] as [CalculationStatement]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
