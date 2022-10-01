﻿create view [dbo].[Contact]
as
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
		[dbo].[Employee]
	where
		[IsEmployee] = 0;