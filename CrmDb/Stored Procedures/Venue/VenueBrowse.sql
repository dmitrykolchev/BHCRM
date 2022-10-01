create procedure [dbo].[VenueBrowse] @filter xml
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
		[Comments],
		[VenuePlaceId],
		[PrimaryVenueTypeId],
		[SecondaryVenueTypeId],
		[Summer],
		[Winter],
		[MaximumNumberOfGuestsForBanquet],
		[MaximumNumberOfGuestsForReception],
		[CateringTypeId],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Venue]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@Id is null or [Id] = @Id);

	return 0;
end
