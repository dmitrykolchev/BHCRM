CREATE PROCEDURE [dbo].[AccountWithEventBrowse] @filter xml
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
	with [A] ([Id]) as
	(
		select distinct	
			[AccountId]
		from
			[dbo].[AccountEvent]
	)
	select
		[Account].[Id],
		[Account].[State],
		[Account].[FileAs],
		[Account].[FullName],
		[Account].[MemberOfAccountId],
		[Account].[TradeMarkId],
		[Account].[AccountTypeId],
		[Account].[AccountGroupId],
		[Account].[IndustryId],
		[Account].[RegionId],
		[Account].[Employees],
		[Account].[AnnualRevenue],
		[Account].[ManagingOrganizationId],
		[Account].[AssignedToEmployeeId],
		[Account].[AssistantEmployeeId],
		[Account].[BudgetItemId],
		[Account].[ExecutiveId],
		[Account].[AccountantId],
		[Account].[Phone],
		[Account].[OtherPhone],
		[Account].[Fax],
		[Account].[Email],
		[Account].[OtherEmail],
		[Account].[WebSite],
		[Account].[BillingAddressStreet],
		[Account].[BillingAddressCity],
		[Account].[BillingAddressRegion],
		[Account].[BillingAddressPostalCode],
		[Account].[BillingAddressCountry],
		[Account].[ShippingAddressStreet],
		[Account].[ShippingAddressCity],
		[Account].[ShippingAddressRegion],
		[Account].[ShippingAddressPostalCode],
		[Account].[ShippingAddressCountry],
		[Account].[Comments],
		[Account].[Created],
		[Account].[CreatedBy],
		[Account].[Modified],
		[Account].[ModifiedBy],
		[Account].[RowVersion]
	from
		[dbo].[Account] inner join [A]
			on ([Account].[Id] = [A].[Id])
	where
		(@Id is null or [Account].[Id] = @Id)
	and
		(@AccountTypeId is null or ([Account].[AccountTypeId] & @AccountTypeId) != 0)
	and
		(@ExcludedAccountTypeId is null or ([Account].[AccountTypeId] & @ExcludedAccountTypeId) = 0)
	and
		(@AllStates = 1 or [Account].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end

