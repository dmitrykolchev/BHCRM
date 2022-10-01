create procedure [dbo].[BudgetItemList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
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
		[BudgetItem].[BudgetItemType]
	from
		[dbo].[BudgetItem] inner join [dbo].[BudgetItemGroup]
			on ([BudgetItem].[BudgetItemGroupId] = [BudgetItemGroup].[Id])
	where
		(@Id is null or [BudgetItem].[Id] = @Id)
		and
		(@AllStates = 1 or [BudgetItem].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
