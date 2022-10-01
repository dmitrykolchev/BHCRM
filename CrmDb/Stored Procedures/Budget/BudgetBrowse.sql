create procedure [dbo].[BudgetBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, 
			@Presentation varchar(256),
			@ServiceRequestId TIdentifier, 
			@AccountId TIdentifier,
			@Id TIdentifier, 
			@PeriodStart date, 
			@PeriodEnd date, 
			@OrganizationId TIdentifier,
			@CurrentEmployeeId TIdentifier,
			@TradeMarkId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@ServiceRequestId = T.c.value('ServiceRequestId[1]', 'TIdentifier'),
		@PeriodStart = T.c.value('PeriodStart[1]', 'date'),
		@PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@TradeMarkId = T.c.value('TradeMarkId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if @PeriodStart is null
		set @PeriodStart = '2000-01-01';
	if @PeriodEnd is null
		set @PeriodEnd = '3000-01-01';

	set @CurrentEmployeeId = [dbo].[GetCurrentEmployeeId]();

	if @Presentation = 'AllBudgets'
	begin
		with [C] ([BudgetId], [StandardValue], [PlannedValue], [ActualValue]) as
		(
			select
				[BudgetId],
				[1],
				[2],
				[3]
			from
				(
					select 
						[CalculationStatement].[BudgetId], [CalculationStatement].[CalculationStage], [CalculationStatementTotal].[TotalPrice] * (1.0 + [VATRate].[Value]) as [TP]
					from 
						[CalculationStatement] inner join [CalculationStatementTotal]
							on ([CalculationStatement].[Id] = [CalculationStatementTotal].[CalculationStatementId])
						inner join [VATRate]
							on ([CalculationStatement].[VATRateId] = [VATRate].[Id])
				) as [C] 
				pivot (sum([TP]) for [CalculationStage] in ([1], [2], [3])) as pvt
		)
		select
			[Budget].[Id],
			[Budget].[State],
			[Budget].[FileAs],
			[Budget].[Number],
			[Budget].[DocumentDate],
			[Budget].[OrganizationId],
			[Budget].[ServiceRequestId],
			[Budget].[BudgetTemplateId],
			[ServiceRequest].[DocumentDate] as [ServiceRequestDocumentDate],
			[ServiceRequest].[Number] as [ServiceRequestNumber],
			[ServiceRequest].[AccountId],
			[ServiceRequest].[VenueProviderId],
			[ServiceRequest].[ReasonId],
			[ServiceRequest].[ServiceRequestTypeId],
			(case when [Budget].[AmountOfGuests] is null then [ServiceRequest].[AmountOfGuests] else [Budget].[AmountOfGuests] end) as [AmountOfGuests],
			[ServiceRequest].[EventDate],
			(case when [Budget].[EventDuration] is null then [ServiceRequest].[EventDuration] else [Budget].[EventDuration] end) as [EventDuration],
			[ServiceRequest].[TradeMarkId],
			[Budget].[Value],
			[C].[StandardValue],
			[C].[PlannedValue],
			[C].[ActualValue],
			[Budget].[Comments],
			[Budget].[Created],
			[Budget].[CreatedBy],
			[Budget].[Modified],
			[Budget].[ModifiedBy],
			[Budget].[RowVersion]
		from
			[dbo].[Budget] inner join [dbo].[ServiceRequest]	
				on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
			left outer join [C]
				on ([Budget].[Id] = [C].[BudgetId])
		where
			(@AllStates = 1 or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
			(@ServiceRequestId is null or [ServiceRequestId] = @ServiceRequestId)
		and 
			(@OrganizationId is null or [Budget].[OrganizationId] = @OrganizationId)
		and
			(@AccountId is null or [ServiceRequest].[AccountId] = @AccountId)
		and
			(@TradeMarkId is null or [ServiceRequest].[TradeMarkId] = @TradeMarkId)
		and
			(isnull([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth]) between @PeriodStart and @PeriodEnd);
	end
	else if @Presentation = 'MyBudgets'
	begin
		with [C] ([BudgetId], [StandardValue], [PlannedValue], [ActualValue]) as
		(
			select
				[BudgetId],
				[1],
				[2],
				[3]
			from
				(
					select 
						[CalculationStatement].[BudgetId], [CalculationStatement].[CalculationStage], [CalculationStatementTotal].[TotalPrice] * (1.0 + [VATRate].[Value]) as [TP]
					from 
						[CalculationStatement] inner join [CalculationStatementTotal]
							on ([CalculationStatement].[Id] = [CalculationStatementTotal].[CalculationStatementId])
						inner join [VATRate]
							on ([CalculationStatement].[VATRateId] = [VATRate].[Id])
				) as [C] 
				pivot (sum([TP]) for [CalculationStage] in ([1], [2], [3])) as pvt
		)
		select
			[Budget].[Id],
			[Budget].[State],
			[Budget].[FileAs],
			[Budget].[Number],
			[Budget].[DocumentDate],
			[Budget].[OrganizationId],
			[Budget].[ServiceRequestId],
			[Budget].[BudgetTemplateId],
			[ServiceRequest].[DocumentDate] as [ServiceRequestDocumentDate],
			[ServiceRequest].[Number] as [ServiceRequestNumber],
			[ServiceRequest].[AccountId],
			[ServiceRequest].[VenueProviderId],
			[ServiceRequest].[ReasonId],
			[ServiceRequest].[ServiceRequestTypeId],
			(case when [Budget].[AmountOfGuests] is null then [ServiceRequest].[AmountOfGuests] else [Budget].[AmountOfGuests] end) as [AmountOfGuests],
			[ServiceRequest].[EventDate],
			(case when [Budget].[EventDuration] is null then [ServiceRequest].[EventDuration] else [Budget].[EventDuration] end) as [EventDuration],
			[ServiceRequest].[TradeMarkId],
			[Budget].[Value],
			[C].[StandardValue],
			[C].[PlannedValue],
			[C].[ActualValue],
			[Budget].[Comments],
			[Budget].[Created],
			[Budget].[CreatedBy],
			[Budget].[Modified],
			[Budget].[ModifiedBy],
			[Budget].[RowVersion]
		from
			[dbo].[Budget] inner join [dbo].[ServiceRequest]	
				on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
			inner join [dbo].[GetServiceRequestListForEmployee](@CurrentEmployeeId) as [S]
				on ([Budget].[ServiceRequestId] = [S].[Id])
			left outer join [C]
				on ([Budget].[Id] = [C].[BudgetId])
		where
			(@AllStates = 1 or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
			(@ServiceRequestId is null or [ServiceRequestId] = @ServiceRequestId)
		and 
			(@OrganizationId is null or [Budget].[OrganizationId] = @OrganizationId)
		and
			(@AccountId is null or [ServiceRequest].[AccountId] = @AccountId)
		and
			(@TradeMarkId is null or [ServiceRequest].[TradeMarkId] = @TradeMarkId)
		and
			(isnull([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth]) between @PeriodStart and @PeriodEnd)
	end
	return 0;
end
