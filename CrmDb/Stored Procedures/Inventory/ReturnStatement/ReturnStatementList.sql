create procedure [dbo].[ReturnStatementList] @filter xml
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
		[ReturnStatement].[Id],
		[ReturnStatement].[State],
		[ReturnStatement].[FileAs],
		[ReturnStatement].[Number],
		[ReturnStatement].[DocumentDate],
		[ReturnStatement].[OrganizationId],
		[ReturnStatement].[StoragePlaceId],
		[ReturnStatement].[SalesOrderId],
		[SalesOrder].[BudgetId],
		[SalesOrder].[CustomerId],
		[ReturnStatement].[TotalCost],
		[ReturnStatement].[TotalPrice]
	from
		[dbo].[ReturnStatement] inner join [dbo].[SalesOrder]
			on ([ReturnStatement].[SalesOrderId] = [SalesOrder].[Id])
	where
		(@Id is null or [ReturnStatement].[Id] = @Id)
		and
		(@AllStates = 1 or [ReturnStatement].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
