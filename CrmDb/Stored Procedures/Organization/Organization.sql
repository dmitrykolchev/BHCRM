﻿create view [dbo].[Organization]
as 
	select
		[Id],
		[State],
		[FileAs],
		[FullName],
		[MemberOfAccountId],
		[AccountTypeId],
		[Phone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[WebSite],
		[ProjectTemplateId],
		[ExecutiveId],
		[AccountantId],
		[BillingAddressStreet],
		[BillingAddressCity],
		[BillingAddressRegion],
		[BillingAddressPostalCode],
		[BillingAddressCountry],
		[ShippingAddressStreet],
		[ShippingAddressCity],
		[ShippingAddressRegion],
		[ShippingAddressPostalCode],
		[ShippingAddressCountry],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Account]
	where
		([AccountTypeId] & 1) = 1

