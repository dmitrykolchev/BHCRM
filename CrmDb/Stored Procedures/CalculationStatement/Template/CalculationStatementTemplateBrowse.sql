create procedure [dbo].[CalculationStatementTemplateBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256),
			@BudgetTemplateId TIdentifier, @IncomeBudgetItemId TIdentifier, @ExpenseBudgetItemId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@BudgetTemplateId = T.c.value('BudgetTemplateId[1]', 'TIdentifier'),
		@IncomeBudgetItemId = T.c.value('IncomeBudgetItemId[1]', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('ExpenseBudgetItemId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

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
		[RowVersion]
	from
		[dbo].[CalculationStatementTemplate]
	where
		(@Id is null or [Id] = @Id)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@BudgetTemplateId is null or [BudgetTemplateId] = @BudgetTemplateId)
	and
		(@IncomeBudgetItemId is null or [IncomeBudgetItemId] = @IncomeBudgetItemId)
	and
		(@ExpenseBudgetItemId is null or [ExpenseBudgetItemId] = @ExpenseBudgetItemId);

	return 0;
end
