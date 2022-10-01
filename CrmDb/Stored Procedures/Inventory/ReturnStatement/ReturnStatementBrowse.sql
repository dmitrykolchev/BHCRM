create procedure [dbo].[ReturnStatementBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256), 
			@PeriodStart date, @PeriodEnd date, @SalesOrderId TIdentifier, @CustomerId TIdentifier, @BudgetId TIdentifier, @OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@SalesOrderId = T.c.value('SalesOrderId[1]', 'TIdentifier'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@BudgetId = T.c.value('BudgetId[1]', 'TIdentifier'),
		@CustomerId = T.c.value('CustomerId[1]', 'TIdentifier'),
		@StoragePlaceId = T.c.value('StoragePlaceId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if(@PeriodStart is null)
		set @PeriodStart = cast('0001-01-01' as date);

	if(@PeriodEnd is null)
		set @PeriodEnd = cast('9999-12-31' as date);

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
		[ReturnStatement].[TotalPrice],
		[ReturnStatement].[Comments],
		[ReturnStatement].[Created],
		[ReturnStatement].[CreatedBy],
		[ReturnStatement].[Modified],
		[ReturnStatement].[ModifiedBy],
		[ReturnStatement].[RowVersion]
	from
		[dbo].[ReturnStatement] inner join [dbo].[SalesOrder]
			on ([ReturnStatement].[SalesOrderId] = [SalesOrder].[Id])
	where
		(@Id is null or [ReturnStatement].[Id] = @Id)
		and
		([ReturnStatement].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [ReturnStatement].[OrganizationId] = @OrganizationId)
		and
		(@StoragePlaceId is null or [ReturnStatement].[StoragePlaceId] = @StoragePlaceId)
		and
		(@BudgetId is null or [SalesOrder].[BudgetId] = @BudgetId)
		and
		(@CustomerId is null or [SalesOrder].[CustomerId] = @CustomerId)
		and
		(@SalesOrderId is null or [ReturnStatement].[SalesOrderId] = @SalesOrderId)
		and
		(@AllStates = 1 or [ReturnStatement].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
