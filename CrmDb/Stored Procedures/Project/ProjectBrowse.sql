create procedure [dbo].[ProjectBrowse] @filter xml
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

	select
		[Project].[Id],
		[Project].[State],
		[Project].[Code],
		[Project].[FileAs],
		[Project].[ProjectTypeId],
		[Project].[OpportunityId],
		[Project].[OrganizationId],
		(select [EmployeeId] from [ProjectMember] where [ProjectId] = [Project].[Id] and [ProjectMemberRoleId] = 1) as  [ProjectManagerId],
		[ServiceRequest].[Id] as [ServiceRequestId],
		[Project].[AccountId],
		[Project].[ResponsibleContactId],
		[Project].[ContractId],
		[Project].[StartDate],
		[Project].[EndDate],
		[Project].[Comments],
		[Project].[Created],
		[Project].[CreatedBy],
		[Project].[Modified],
		[Project].[ModifiedBy],
		[Project].[RowVersion]
	from
		[dbo].[Project] left outer join [dbo].[ServiceRequest]
			on ([Project].[Id] = [ServiceRequest].[ProjectId])
	where
		(@Id is null or [Project].[Id] = @Id)
		and
		(@AllStates = 1 or [Project].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
