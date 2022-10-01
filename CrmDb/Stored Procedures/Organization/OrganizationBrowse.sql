create procedure [dbo].[OrganizationBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

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
		[dbo].[Organization]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@Id is null or [Id] = @Id);

	return 0;
end
