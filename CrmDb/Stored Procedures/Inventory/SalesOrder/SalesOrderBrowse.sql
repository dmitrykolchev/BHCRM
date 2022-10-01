create procedure [dbo].[SalesOrderBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256),
			@PeriodStart date, @PeriodEnd date, @CustomerId TIdentifier, @BudgetId TIdentifier, @OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
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
		[SalesOrder].[Id],
		[SalesOrder].[State],
		[SalesOrder].[FileAs],
		[SalesOrder].[Number],
		[SalesOrder].[DocumentDate],
		[SalesOrder].[OrganizationId],
		[SalesOrder].[StoragePlaceId],
		[SalesOrder].[BudgetId],
		[Budget].[Number] as [BudgetNumber],
		coalesce([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth]) as [EventDate],
		[ServiceRequest].[AccountId] as [ServiceRequestAccountId],
		[ServiceRequest].[Number] as [ServiceRequestNumber],
		[SalesOrder].[BudgetItemGroupId],
		[SalesOrder].[BudgetItemId],
		[SalesOrder].[CustomerId],
		[SalesOrder].[TotalCost],
		[SalesOrder].[TotalPrice],
		[SalesOrder].[Comments],
		[SalesOrder].[Created],
		[SalesOrder].[CreatedBy],
		[SalesOrder].[Modified],
		[SalesOrder].[ModifiedBy],
		[SalesOrder].[RowVersion]
	from
		[dbo].[SalesOrder] left outer join [dbo].[Budget]	
			on ([SalesOrder].[BudgetId] = [Budget].[Id])
		left outer join [ServiceRequest]
			on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
	where
		(@Id is null or [SalesOrder].[Id] = @Id)
		and
		([SalesOrder].[DocumentDate] between @PeriodStart and @PeriodEnd)
		and
		(@OrganizationId is null or [SalesOrder].[OrganizationId] = @OrganizationId)
		and
		(@StoragePlaceId is null or [SalesOrder].[StoragePlaceId] = @StoragePlaceId)
		and
		(@BudgetId is null or [SalesOrder].[BudgetId] = @BudgetId)
		and
		(@CustomerId is null or [SalesOrder].[CustomerId] = @CustomerId)
		and
		(@AllStates = 1 or [SalesOrder].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
