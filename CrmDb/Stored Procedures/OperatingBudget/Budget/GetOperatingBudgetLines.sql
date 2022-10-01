CREATE FUNCTION [dbo].[GetOperatingBudgetLines]
(
	@DocumentTypeId int,
	@DocumentId TIdentifier,
	@BudgetItemId TIdentifier,
	@Tag int
)
RETURNS @Lines TABLE
(
	[OperatingBudgetLineId] int not null,
	[OperatingBudgetId] TIdentifier not null,
	[CalculationStage] int not null,
	[DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[BudgetItemId] TIdentifier not null,
	[Tag] int not null,
	[OrdinalPosition] int not null,
	[AccountId] TIdentifier null,
	[FileAs] TName not null,
	[Comments] nvarchar(1024) null,
	[Amount] TAmount not null,
	[Price] TMoney not null
)
as
begin
	insert @Lines
	select
		[OperatingBudgetLineId],
		[OperatingBudgetId],
		[CalculationStage],
		[DocumentTypeId],
		[DocumentId],
		[BudgetItemId],
		[Tag],
		[OrdinalPosition],
		[AccountId],
		[FileAs],
		[Comments],
		[Amount],
		[Price]
	from
		[dbo].[OperatingBudgetLine]
	where
		[DocumentTypeId] = @DocumentTypeId and [DocumentId] = @DocumentId and [BudgetItemId] = @BudgetItemId and [Tag] = @Tag;

	return
end
