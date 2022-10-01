create procedure [dbo].[AccountBrowse] @filter xml
as
begin
	set nocount on;

	declare @AccountTypeId int, @AllStates bit, @ExcludedAccountTypeId int, @Id TIdentifier, @Presentation varchar(256);

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@AccountTypeId = T.c.value('AccountTypeId[1]', 'int'),
		@ExcludedAccountTypeId = T.c.value('ExcludedAccountTypeId[1]', 'int'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from	
		@filter.nodes('/Filter') as T(c);

	if @Presentation = 'MyAccounts'
	begin
		exec [dbo].[MyAccountBrowse] @filter;
	end
	else if @Presentation = 'AllAccounts'
	begin
		exec [dbo].[AllAccountBrowse] @filter;
	end
	else if @Presentation = 'AccountsWithEvent'
		exec [dbo].[AccountWithEventBrowse] @filter;
	else
	begin
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
			[Comments],
			[Created],
			[CreatedBy],
			[Modified],
			[ModifiedBy],
			[RowVersion]
		from
			[dbo].[Account]
		where
			(@Id is null or [Id] = @Id)
		and
			(@AccountTypeId is null or ([AccountTypeId] & @AccountTypeId) != 0)
		and
			(@ExcludedAccountTypeId is null or ([AccountTypeId] & @ExcludedAccountTypeId) = 0)
		and
			(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));
	end
	return 0;
end
