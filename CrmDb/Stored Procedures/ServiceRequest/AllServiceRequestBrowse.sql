create procedure [dbo].[AllServiceRequestBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @AccountId TIdentifier, @VenueProviderId TIdentifier, @ProjectMemberId TIdentifier, @PeriodStart date, @PeriodEnd date,
			@OrganizationId TIdentifier, @TradeMarkId TIdentifier, @ProjectId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'TIdentifier'),
		@TradeMarkId = T.c.value('TradeMarkId[1]', 'TIdentifier'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@VenueProviderId = T.c.value('VenueProviderId[1]', 'TIdentifier'),
		@ProjectMemberId = T.c.value('ProjectMemberId[1]', 'TIdentifier'),
		@ProjectId = T.c.value('ProjectId[1]', 'TIdentifier'),
		@PeriodStart = isnull(T.c.value('PeriodStart[1]', 'date'), cast('0001-01-01' as date)),
		@PeriodEnd = isnull(T.c.value('PeriodEnd[1]', 'date'), cast('9999-12-31' as date))
	from
		@filter.nodes('/Filter') as T(c);


	with [M] ([ProjectId], [ProjectManagerId], [ProjectMember1Id], [ProjectMember2Id], [ProjectMember3Id], [ProjectMember4Id]) as
	(
		select 
			[ProjectId],
			min(case when [ProjectMemberRoleId] = 1 then [EmployeeId] else null end),
			min(case when [ProjectMemberRoleId] = 2 then [EmployeeId] else null end),
			min(case when [ProjectMemberRoleId] = 3 then [EmployeeId] else null end),
			min(case when [ProjectMemberRoleId] = 4 then [EmployeeId] else null end),
			min(case when [ProjectMemberRoleId] = 5 then [EmployeeId] else null end)
		from 
			[ProjectMember]
		group by
			[ProjectId]
	)
	, [A] ([DocumentId], [AttachmentCount]) as
	(
		select 
			[DocumentId], 
			count(*) 
		from 
			DocumentAttachment
		where
			[DocumentTypeId] = [dbo].[GetDocumentTypeId]('ServiceRequest')
		group by
			[DocumentId]
	)
	, [C] ([BudgetId], [ServiceRequestId], [BudgetValue]) as
	(
		select
			[BudgetId],
			[ServiceRequestId],
			(case when [BudgetState] = 1 then [1] when [BudgetState] = 2 then [2] else [3] end)
		from
			(
				select 
					[CalculationStatement].[BudgetId], 
					[Budget].[State] as [BudgetState],
					[Budget].[ServiceRequestId],
					[CalculationStatement].[CalculationStage], 
					[CalculationStatementTotal].[TotalPrice] * (1.0 + [VATRate].[Value]) as [TP]
				from 
					[CalculationStatement] inner join [CalculationStatementTotal]
						on ([CalculationStatement].[Id] = [CalculationStatementTotal].[CalculationStatementId])
					inner join [VATRate]
						on ([CalculationStatement].[VATRateId] = [VATRate].[Id])
					inner join [Budget]
						on ([CalculationStatement].[BudgetId] = [Budget].[Id])
			) as [C] 
			pivot (sum([TP]) for [CalculationStage] in ([1], [2], [3])) as pvt	
	)
	, [CC] ([ServiceRequestId], [BudgetValue]) as
	(
		select
			[ServiceRequestId],
			sum([BudgetValue])
		from
			[C]
		group by
			[ServiceRequestId]
	)
	select
		[ServiceRequest].[Id],
		[ServiceRequest].[State],
		[ServiceRequest].[Number],
		[ServiceRequest].[FileAs],
		[ServiceRequest].[DocumentDate],
		[ServiceRequest].[TradeMarkId],
		[ServiceRequest].[OrganizationId],
		[M].[ProjectManagerId] as [ResponsibleEmployeeId],
		[M].[ProjectManagerId],
		[M].[ProjectMember1Id],
		[M].[ProjectMember2Id],
		[M].[ProjectMember3Id],
		[M].[ProjectMember4Id],
		isnull([A].[AttachmentCount], 0) as [AttachmentCount],
		[ServiceRequest].[AccountId],
		[ServiceRequest].[CustomerId],
		[ServiceRequest].[VenueProviderId],
		[ServiceRequest].[AgentId],
		[ServiceRequest].[ResponsibleContactId],
		[ServiceRequest].[ServiceRequestTypeId],
		[ServiceRequest].[ServiceLevelId],
		[ServiceRequest].[ReasonId],
		[ServiceRequest].[LeadSourceId],
		[ServiceRequest].[ProjectId],
		[ServiceRequest].[AmountOfGuests],
		[ServiceRequest].[Value],
		[CC].[BudgetValue],
		[ServiceRequest].[Mileage],
		[ServiceRequest].[EventLocation],
		[ServiceRequest].[EventMonth],
		[ServiceRequest].[EventDate],
		[ServiceRequest].[EventDuration],
		[ServiceRequest].[Comments],
		[ServiceRequest].[Created],
		[ServiceRequest].[CreatedBy],
		[ServiceRequest].[Modified],
		[ServiceRequest].[ModifiedBy],
		[ServiceRequest].[RowVersion]
	from
		[dbo].[ServiceRequest] inner join [dbo].[Project]
			on ([ServiceRequest].[ProjectId] = [Project].[Id])
		left outer join [M]
			on ([Project].[Id] = [M].[ProjectId])
		left outer join [A]
			on ([ServiceRequest].[Id] = [A].[DocumentId])
		left outer join [CC]
			on ([ServiceRequest].[Id] = [CC].[ServiceRequestId])
	where
		(@AllStates = 1 or [ServiceRequest].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@Id is null or [ServiceRequest].[Id] = @Id)
	and
		(@AccountId is null or [ServiceRequest].[AccountId] = @AccountId)
	and
		(@VenueProviderId is null or [ServiceRequest].[VenueProviderId] = @VenueProviderId)
	and
		(isnull([ServiceRequest].[EventDate], [ServiceRequest].[EventMonth]) between @PeriodStart and @PeriodEnd)
	and
		(@ProjectMemberId is null or @ProjectMemberId in ([M].[ProjectManagerId], [M].[ProjectManagerId], [M].[ProjectMember1Id], [M].[ProjectMember2Id], [M].[ProjectMember3Id], [M].[ProjectMember4Id]))
	and
		(@OrganizationId is null or [ServiceRequest].[OrganizationId] = @OrganizationId)
	and
		(@TradeMarkId is null or [ServiceRequest].[TradeMarkId] = @TradeMarkId)
	and 
		(@ProjectId is null or [ServiceRequest].[ProjectId] = @ProjectId);
	return 0;
end
