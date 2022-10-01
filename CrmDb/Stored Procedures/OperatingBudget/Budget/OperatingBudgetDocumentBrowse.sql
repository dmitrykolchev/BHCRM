CREATE PROCEDURE [dbo].[OperatingBudgetDocumentBrowse] @xml xml
AS
begin
	set nocount on;
	declare @OperatingBudgetId TIdentifier, @BudgetItemId TIdentifier, @CalculationStage int;

	select
		@OperatingBudgetId = T.c.value('@OperatingBudgetId', 'TIdentifier'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'TIdentifier'),
		@CalculationStage = T.c.value('@CalculationStage', 'int')
	from
		@xml.nodes('OperatingBudgetDocumentBrowse') as T(c);

	with [D] ([DocumentTypeId], [DocumentId], [TotalValue]) as
	(
		select
			[DocumentTypeId],
			[DocumentId],
			sum([Amount] * [Price]) as [TotalValue]
		from
			[OperatingBudgetLine]
		where
			[OperatingBudgetId] = @OperatingBudgetId and [BudgetItemId] = @BudgetItemId and [CalculationStage] = @CalculationStage
		group by
			[DocumentTypeId],
			[DocumentId]
	),
	[OperatingBudgetDocumentItem] ([DocumentTypeId], [DocumentId], [State], [FileAs], [Number], [DocumentDate], [OrganizationId], [Comments], [TotalValue]) as
	(
		select
			[L].[DocumentTypeId],
			[L].[DocumentId],
			[L].[State],
			[L].[FileAs],
			[L].[Number],
			[L].[DocumentDate],
			[L].[OrganizationId],
			[L].[Comments],
			[D].[TotalValue]
		from
			[DocumentLog] as [L] inner join [D]
				on ([L].[DocumentTypeId] = [D].[DocumentTypeId] and [L].[DocumentId] = [D].[DocumentId])
	)
	select
		[DocumentTypeId], 
		[DocumentId], 
		[State], 
		[FileAs], 
		[Number], 
		[DocumentDate], 
		[OrganizationId], 
		[Comments], 
		[TotalValue]
	from	
		[OperatingBudgetDocumentItem]
	for xml auto, binary base64, root('Response');


	return 0;
end

go

grant execute on [dbo].[OperatingBudgetDocumentBrowse] to public;
go
