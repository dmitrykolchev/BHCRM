create procedure [dbo].[VenueList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[FullName],
		[MemberOfAccountId],
		[TradeMarkId],
		[AccountTypeId],
		[AccountGroupId],
		[IndustryId],
		[RegionId],
		[Employees],
		[AnnualRevenue],
		[ManagingOrganizationId],
		[AssignedToEmployeeId],
		[AssistantEmployeeId],
		[ExecutiveId],
		[AccountantId],
		[Phone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[WebSite],
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
		[VenuePlaceId],
		[PrimaryVenueTypeId],
		[SecondaryVenueTypeId],
		[Summer],
		[Winter],
		[MaximumNumberOfGuestsForBanquet],
		[MaximumNumberOfGuestsForReception],
		[CateringTypeId]
	from
		[dbo].[Venue]
	where
		(@Id is null or [Id] = @Id)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
