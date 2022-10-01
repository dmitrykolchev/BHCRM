create procedure [dbo].[EmployeeBrowse] @filter xml
as
begin
	set nocount on;
	
	declare @OrganizationId int, @DivisionId int, @Id int, @AllStates bit, @ProjectId TIdentifier, @ProjectMemberRoleId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'int'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'int'),
		@DivisionId = T.c.value('DivisionId[1]', 'int'),
		@ProjectId =  T.c.value('ProjectId[1]', 'int'),
		@ProjectMemberRoleId = T.c.value('ProjectMemberRoleId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[EmployeeAccountId],
		[FileAs],
		[AccountId],
		[TradeMarkId],
		[PositionId],
		[ReportsToEmployeeId],
		[DivisionId],
		[FirstName],
		[MiddleName],
		[LastName],
		[BirthDate],
		[Gender],
		[BusinessPhone],
		[MobilePhone],
		[HomePhone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[Assistant],
		[AssistantPhone],
		[PrimaryAddressStreet],
		[PrimaryAddressCity],
		[PrimaryAddressRegion],
		[PrimaryAddressPostalCode],
		[PrimaryAddressCountry],
		[AlternateAddressStreet],
		[AlternateAddressCity],
		[AlternateAddressRegion],
		[AlternateAddressPostalCode],
		[AlternateAddressCountry],
		[UserId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Employee]
	where
		[IsEmployee] = 1
	and
		(@Id is null or [Id] = @Id)
	and
		((@OrganizationId is null) or ([AccountId] = @OrganizationId))
	and
		((@DivisionId is null) or ([DivisionId] = @DivisionId))
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint')	from @filter.nodes('Filter/State') as T(c)))
	and
		(@ProjectId is null or [Id] in (select [EmployeeId] from [ProjectMember] 
										where [ProjectId] = @ProjectId and (@ProjectMemberRoleId is null or [ProjectMemberRoleId] = @ProjectMemberRoleId)));

	return 0;
end
