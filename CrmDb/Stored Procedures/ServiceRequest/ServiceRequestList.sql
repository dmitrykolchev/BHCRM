create procedure [dbo].[ServiceRequestList]
as
begin
	set nocount on;
	
	declare @ServiceRequestTypeId int = [dbo].[GetDocumentTypeId]('ServiceRequest');

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
	), [A] ([DocumentId], [AttachmentCount]) as
	(
		select 
			[DocumentId], 
			count(*) 
		from 
			[DocumentAttachment]
		where
			[DocumentTypeId] = @ServiceRequestTypeId
		group by
			[DocumentId]
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
			on ([ServiceRequest].[Id] = [A].[DocumentId]);

	return 0;
end
