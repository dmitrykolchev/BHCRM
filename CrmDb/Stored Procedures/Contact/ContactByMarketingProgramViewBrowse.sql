CREATE PROCEDURE [dbo].[ContactByMarketingProgramViewBrowse] @filter xml
as
begin
	set nocount on;

	declare @AccountId int, @Id TIdentifier, @AllStates bit;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[ContactGroupId],
		[ContactRoleId],
		[AssignedToEmployeeId],
		[FirstName],
		[MiddleName],
		[LastName],
		[AccountId],
		[ReportsToEmployeeId],
		[LeadSourceId],
		[Title],
		[Department],
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
		[MarketingProgramTypeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ContactByMarketingProgramView]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@AccountId is null or [AccountId] = @AccountId)
	and
		(@Id is null or [Id] = @Id);

	return 0;
end
