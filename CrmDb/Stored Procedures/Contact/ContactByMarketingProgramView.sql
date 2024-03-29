﻿create view [dbo].[ContactByMarketingProgramView]
as
	select
		[Contact].[Id],
		[Contact].[State],
		[Contact].[FileAs],
		[Contact].[ContactGroupId],
		[Contact].[ContactRoleId],
		[Contact].[AssignedToEmployeeId],
		[Contact].[FirstName],
		[Contact].[MiddleName],
		[Contact].[LastName],
		[Contact].[AccountId],
		[Contact].[ReportsToEmployeeId],
		[Contact].[LeadSourceId],
		[Contact].[Title],
		[Contact].[Department],
		[Contact].[BirthDate],
		[Contact].[Gender],
		[Contact].[BusinessPhone],
		[Contact].[MobilePhone],
		[Contact].[HomePhone],
		[Contact].[OtherPhone],
		[Contact].[Fax],
		[Contact].[Email],
		[Contact].[OtherEmail],
		[Contact].[Assistant],
		[Contact].[AssistantPhone],
		[Contact].[PrimaryAddressStreet],
		[Contact].[PrimaryAddressCity],
		[Contact].[PrimaryAddressRegion],
		[Contact].[PrimaryAddressPostalCode],
		[Contact].[PrimaryAddressCountry],
		[Contact].[AlternateAddressStreet],
		[Contact].[AlternateAddressCity],
		[Contact].[AlternateAddressRegion],
		[Contact].[AlternateAddressPostalCode],
		[Contact].[AlternateAddressCountry],
		[AccountMarketingProgramType].[MarketingProgramTypeId],
		[Contact].[Comments],
		[Contact].[Created],
		[Contact].[CreatedBy],
		[Contact].[Modified],
		[Contact].[ModifiedBy],
		[Contact].[RowVersion]
	from
		[dbo].[Contact] inner join [dbo].[AccountMarketingProgramType]
			on ([Contact].[Id] = [AccountMarketingProgramType].[ContactId])
