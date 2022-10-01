create procedure [dbo].[CalculationStatementTemplateGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'CalculationStatementTemplate';

	select
		[Id],
		[State],
		[FileAs],
		[BudgetTemplateId],
		[IncomeBudgetItemId],
		[ExpenseBudgetItemId],
		[DependsOnAmountOfPersons],
		[AmountOnly],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[CalculationStatementTemplateSectionId],
			[CalculationStatementTemplateId],
			[OrdinalPosition],
			[FileAs],
			[ProductCategoryId],
			[Comments]
		from 
			[CalculationStatementTemplateSection]
		where	
			[CalculationStatementTemplateId] = @Id for xml auto, type) as [Sections],
		(select
			[CalculationStatementTemplateLineId], [CalculationStatementTemplateSectionId], [CalculationStatementTemplateId], 
			[OrdinalPosition], [ProductId], [FileAs], [Comments], [Duration], [Amount],
			[DependsOnAmountOfPersons], [DependsOnEventDuration], [Price], [Cost]
		from
			[CalculationStatementTemplateLine]
		where
			[CalculationStatementTemplateId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[CalculationStatementTemplate] as [CalculationStatementTemplate]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
