create procedure [dbo].[BudgetItemBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @BudgetItemGroupId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@BudgetItemGroupId = T.c.value('BudgetItemGroupId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[BudgetItem].[Id],
		[BudgetItem].[State],
		[BudgetItem].[Code],
		[BudgetItem].[FileAs],
		[BudgetItem].[BudgetItemGroupId],
		[BudgetItemGroup].[BudgetItemGroupType],
		[BudgetItemGroup].[IsExpenseGroup],
		[BudgetItem].[BudgetItemType],
		[BudgetItem].[Comments],
		[BudgetItem].[Created],
		[BudgetItem].[CreatedBy],
		[BudgetItem].[Modified],
		[BudgetItem].[ModifiedBy],
		[BudgetItem].[RowVersion]
	from
		[dbo].[BudgetItem] inner join [dbo].[BudgetItemGroup]
			on ([BudgetItem].[BudgetItemGroupId] = [BudgetItemGroup].[Id])
	where
		(@AllStates = 1 or [BudgetItem].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@BudgetItemGroupId is null or [BudgetItem].[BudgetItemGroupId] = @BudgetItemGroupId);

	return 0;
end
