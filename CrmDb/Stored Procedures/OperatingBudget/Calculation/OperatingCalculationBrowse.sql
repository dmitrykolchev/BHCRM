create procedure [dbo].[OperatingCalculationBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256), @OrganizationId TIdentifier, @OperatingBudgetId TIdentifier, @BudgetItemId TIdentifier, @CalculationStage int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@OperatingBudgetId = T.c.value('OperatingBudgetId[1]', 'TIdentifier'),
		@BudgetItemId = T.c.value('BudgetItemId[1]', 'TIdentifier'),
		@CalculationStage = T.c.value('CalculationStage[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

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
		[RowVersion]
	from
		[dbo].[OperatingCalculation]
	where
		(@Id is null or [Id] = @Id)
		and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId)
		and
		(@OperatingBudgetId is null or [OperatingBudgetId] = @OperatingBudgetId)
		and
		(@BudgetItemId is null or [BudgetItemId] = @BudgetItemId)
		and
		(@CalculationStage is null or [CalculationStage] = @CalculationStage)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
