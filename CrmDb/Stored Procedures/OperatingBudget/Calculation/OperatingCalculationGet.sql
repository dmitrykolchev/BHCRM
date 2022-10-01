create procedure [dbo].[OperatingCalculationGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'OperatingCalculation';

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[OperatingBudgetId],
		[BudgetItemId],
		[CalculationStage],
		[TotalValue],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]
		from
			[OperatingBudgetLine] as [OperatingCalculationLine]
		where	
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[OperatingCalculation] as [OperatingCalculation]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
