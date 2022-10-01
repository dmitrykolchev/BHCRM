create procedure [dbo].[AccountByMarketingProgramViewList] @filter xml
as
begin
	set nocount on;

	declare @AccountTypeId int, @AllStates bit, @ExcludedAccountTypeId int, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@AccountTypeId = T.c.value('AccountTypeId[1]', 'int'),
		@ExcludedAccountTypeId = T.c.value('ExcludedAccountTypeId[1]', 'int')
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
		[BudgetItemId],
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
		[MarketingProgramTypeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[AccountByMarketingProgramView]
	where
		(@Id is null or [Id] = @Id)
	and
		(@AccountTypeId is null or ([AccountTypeId] & @AccountTypeId) != 0)
	and
		(@ExcludedAccountTypeId is null or ([AccountTypeId] & @ExcludedAccountTypeId) = 0)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
