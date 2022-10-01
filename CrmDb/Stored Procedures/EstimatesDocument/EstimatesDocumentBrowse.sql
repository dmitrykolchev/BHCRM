create procedure [dbo].[EstimatesDocumentBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256);

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from
		@filter.nodes('/Filter') as T(c);

	if @Presentation = 'AllEstimates'
	begin
		with [E] ([EstimatesDocumentId], [TotalPrice], [TotalCost], [NonCashCost]) as
		(
			select
				[L].[EstimatesDocumentId],
				sum([L].[Amount] * [L].[Price]),
				sum([L].[CashCost] / (1 - [R].[Value]) + [L].[NonCashCost]),
				sum([L].[NonCashCost])
			from
				[dbo].[EstimatesDocumentLine] as [L] inner join [dbo].[EstimatesDocument] as [D]
					on ([L].[EstimatesDocumentId] = [D].[Id])
				inner join [ExtraCostRate] as [R]
					on ([D].[ExtraCostRateId] = [R].[Id])
			group by
				[EstimatesDocumentId]
		)
		select
			[EstimatesDocument].[Id],
			[EstimatesDocument].[State],
			[EstimatesDocument].[FileAs],
			[EstimatesDocument].[Number],
			[EstimatesDocument].[DocumentDate],
			[ServiceRequest].[AccountId],
			[ServiceRequest].[VenueProviderId],
			[ServiceRequest].[ReasonId],
			[ServiceRequest].[ServiceRequestTypeId],
			[EstimatesDocument].[OrganizationId],
			[EstimatesDocument].[ServiceRequestId],
			[EstimatesDocument].[VATRateId],
			[EstimatesDocument].[ExtraCostRateId],
			[EstimatesDocument].[Commission],
			[EstimatesDocument].[Margin],
			[EstimatesDocument].[Discount],
			[E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * (1 + [VATRate].[Value]) as [TotalPrice],
			[E].[TotalCost] + [E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * [VATRate].[Value] / 3.0  as [TotalCost],
			([E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * (1 + [VATRate].[Value])) - ([E].[TotalCost] + [E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * [VATRate].[Value] / 3.0) as [Income],
			[EstimatesDocument].[Comments],
			[EstimatesDocument].[Created],
			[EstimatesDocument].[CreatedBy],
			[EstimatesDocument].[Modified],
			[EstimatesDocument].[ModifiedBy],
			[EstimatesDocument].[RowVersion]
		from
			[dbo].[EstimatesDocument] left outer join [E]
				on ([EstimatesDocument].[Id] = [E].[EstimatesDocumentId])
			inner join [dbo].[VATRate]	
				on ([EstimatesDocument].[VATRateId] = [VATRate].[Id])
			inner join [dbo].[ServiceRequest]
				on ([EstimatesDocument].[ServiceRequestId] = [ServiceRequest].[Id])
		where
			(@Id is null or [EstimatesDocument].[Id] = @Id)
			and
			(@AllStates = 1 or [EstimatesDocument].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));
	end
	else
	begin
		declare @CurrentEmployeeId TIdentifier;
		set @CurrentEmployeeId = [dbo].[GetCurrentEmployeeId]();

		with [E] ([EstimatesDocumentId], [TotalPrice], [TotalCost], [NonCashCost]) as
		(
			select
				[L].[EstimatesDocumentId],
				sum([L].[Amount] * [L].[Price]),
				sum([L].[CashCost] / (1 - [R].[Value]) + [L].[NonCashCost]),
				sum([L].[NonCashCost])
			from
				[dbo].[EstimatesDocumentLine] as [L] inner join [dbo].[EstimatesDocument] as [D]
					on ([L].[EstimatesDocumentId] = [D].[Id])
				inner join [ExtraCostRate] as [R]
					on ([D].[ExtraCostRateId] = [R].[Id])
			group by
				[EstimatesDocumentId]
		)
		select
			[EstimatesDocument].[Id],
			[EstimatesDocument].[State],
			[EstimatesDocument].[FileAs],
			[EstimatesDocument].[Number],
			[EstimatesDocument].[DocumentDate],
			[ServiceRequest].[AccountId],
			[ServiceRequest].[VenueProviderId],
			[ServiceRequest].[ReasonId],
			[ServiceRequest].[ServiceRequestTypeId],
			[EstimatesDocument].[OrganizationId],
			[EstimatesDocument].[ServiceRequestId],
			[EstimatesDocument].[VATRateId],
			[EstimatesDocument].[ExtraCostRateId],
			[EstimatesDocument].[Commission],
			[EstimatesDocument].[Margin],
			[EstimatesDocument].[Discount],
			[E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * (1 + [VATRate].[Value]) as [TotalPrice],
			[E].[TotalCost] + [E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * [VATRate].[Value] / 3.0  as [TotalCost],
			([E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * (1 + [VATRate].[Value])) - ([E].[TotalCost] + [E].[TotalPrice] * (1 + [EstimatesDocument].[Commission]) * [VATRate].[Value] / 3.0) as [Income],
			[EstimatesDocument].[Comments],
			[EstimatesDocument].[Created],
			[EstimatesDocument].[CreatedBy],
			[EstimatesDocument].[Modified],
			[EstimatesDocument].[ModifiedBy],
			[EstimatesDocument].[RowVersion]
		from
			[dbo].[EstimatesDocument] left outer join [E]
				on ([EstimatesDocument].[Id] = [E].[EstimatesDocumentId])
			inner join [dbo].[VATRate]	
				on ([EstimatesDocument].[VATRateId] = [VATRate].[Id])
			inner join [dbo].[ServiceRequest]
				on ([EstimatesDocument].[ServiceRequestId] = [ServiceRequest].[Id])
		where
			(@Id is null or [EstimatesDocument].[Id] = @Id)
			and
			(@AllStates = 1 or [EstimatesDocument].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
			and
			exists(select * from [dbo].[ProjectMember] where [ProjectId] = [ServiceRequest].[ProjectId] and [EmployeeId] = @CurrentEmployeeId);
	end
	return 0;
end
