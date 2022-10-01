﻿create procedure [dbo].[MyContactBrowse] @filter xml
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

	declare @EmployeeId TIdentifier;

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
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Contact]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@AccountId is null or [AccountId] = @AccountId)
	and
		(@Id is null or [Id] = @Id)
	and
		([AssignedToEmployeeId] = @EmployeeId or [AccountId] in (select [Id] from [dbo].[GetAccountsOfEmployee](@EmployeeId)));

	return 0;
end