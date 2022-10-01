CREATE PROCEDURE [dbo].[AccountUpdateInternal] @xml xml, @RootNode nvarchar(128), @Id TIdentifier out
as
begin
	set nocount on;

	declare @FileAs TName,
			@FullName nvarchar(1024),
			@MemberOfAccountId TIdentifier,
			@TradeMarkId TIdentifier,
			@AccountTypeId int,
			@AccountGroupId TIdentifier,
			@IndustryId TIdentifier,
			@RegionId TIdentifier,
			@Employees int,
			@AnnualRevenue money,
			@ManagingOrganizationId TIdentifier,
			@AssignedToEmployeeId TIdentifier,
			@AssistantEmployeeId TIdentifier,
			@BudgetItemId TIdentifier,
			@ExecutiveId TIdentifier,
			@AccountantId TIdentifier,
			@Phone varchar(128),
			@OtherPhone varchar(128),
			@Fax varchar(128),
			@Email varchar(128),
			@OtherEmail varchar(128),
			@WebSite varchar(128),
			@BillingAddressStreet nvarchar(256),
			@BillingAddressCity nvarchar(64),
			@BillingAddressRegion nvarchar(64),
			@BillingAddressPostalCode nvarchar(10),
			@BillingAddressCountry nvarchar(64),
			@ShippingAddressStreet nvarchar(256),
			@ShippingAddressCity nvarchar(64),
			@ShippingAddressRegion nvarchar(64),
			@ShippingAddressPostalCode nvarchar(10),
			@ShippingAddressCountry nvarchar(64),
			@Comments nvarchar(max),
			@RowVersion timestamp

	select
		@Id = T.c.value('@Id', 'int'),
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@FullName = T.c.value('@FullName', 'nvarchar(1024)'),
		@MemberOfAccountId = T.c.value('@MemberOfAccountId', 'int'),
		@TradeMarkId = T.c.value('@TradeMarkId', 'int'),
		@AccountTypeId = T.c.value('@AccountTypeId', 'int'),
		@AccountGroupId = T.c.value('@AccountGroupId', 'int'),
		@IndustryId = T.c.value('@IndustryId', 'int'),
		@RegionId = T.c.value('@RegionId', 'int'),
		@Employees = T.c.value('@Employees', 'int'),
		@AnnualRevenue = T.c.value('@AnnualRevenue', 'money'),
		@ManagingOrganizationId = T.c.value('@ManagingOrganizationId', 'int'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'int'),
		@AssistantEmployeeId = T.c.value('@AssistantEmployeeId', 'int'),
		@BudgetItemId = T.c.value('@BudgetItemId', 'int'),
		@ExecutiveId = T.c.value('@ExecutiveId', 'int'),
		@AccountantId = T.c.value('@AccountantId', 'int'),
		@Phone = T.c.value('@Phone', 'varchar(128)'),
		@OtherPhone = T.c.value('@OtherPhone', 'varchar(128)'),
		@Fax = T.c.value('@Fax', 'varchar(128)'),
		@Email = T.c.value('@Email', 'varchar(128)'),
		@OtherEmail = T.c.value('@OtherEmail', 'varchar(128)'),
		@WebSite = T.c.value('@WebSite', 'varchar(128)'),
		@BillingAddressStreet = T.c.value('@BillingAddressStreet', 'varchar(256)'),
		@BillingAddressCity = T.c.value('@BillingAddressCity', 'varchar(64)'),
		@BillingAddressRegion = T.c.value('@BillingAddressRegion', 'varchar(64)'),
		@BillingAddressPostalCode = T.c.value('@BillingAddressPostalCode', 'varchar(10)'),
		@BillingAddressCountry = T.c.value('@BillingAddressCountry', 'varchar(64)'),
		@ShippingAddressStreet = T.c.value('@ShippingAddressStreet', 'varchar(256)'),
		@ShippingAddressCity = T.c.value('@ShippingAddressCity', 'varchar(64)'),
		@ShippingAddressRegion = T.c.value('@ShippingAddressRegion', 'varchar(64)'),
		@ShippingAddressPostalCode = T.c.value('@ShippingAddressPostalCode', 'varchar(10)'),
		@ShippingAddressCountry = T.c.value('@ShippingAddressCountry', 'varchar(64)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from	
		@xml.nodes('/*') as T(c);

	if ((select [AccountTypeId] from [Account] where [Id] = @Id) & 0x08) = 0x08
		throw 50489, '#CannotChangeEmployeeAccount', 1;

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[AccountGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'Account', @Id, null, @LogData, null;
	if @@error <> 0 or @result <> 0
		return 1;
	-- end log document state entry	

	update [dbo].[Account]
	set
		[FileAs] = @FileAs,
		[FullName] = @FullName,
		[MemberOfAccountId] = @MemberOfAccountId,
		[TradeMarkId] = @TradeMarkId,
		[AccountTypeId] = @AccountTypeId,
		[AccountGroupId] = @AccountGroupId,
		[IndustryId] = @IndustryId,
		[RegionId] = @RegionId,
		[Employees] = @Employees,
		[AnnualRevenue] = @AnnualRevenue,
		[ManagingOrganizationId] = @ManagingOrganizationId,
		[AssignedToEmployeeId] = @AssignedToEmployeeId,
		[AssistantEmployeeId] = @AssistantEmployeeId,
		[BudgetItemId] = @BudgetItemId,
		[ExecutiveId] = @ExecutiveId,
		[AccountantId] = @AccountantId,
		[Phone] = @Phone,
		[OtherPhone] = @OtherPhone,
		[Fax] = @Fax,
		[Email] = @Email,
		[OtherEmail] = @OtherEmail,
		[WebSite] = @WebSite,
		[BillingAddressStreet] = @BillingAddressStreet,
		[BillingAddressCity] = @BillingAddressCity,
		[BillingAddressRegion] = @BillingAddressRegion,
		[BillingAddressPostalCode] = @BillingAddressPostalCode,
		[BillingAddressCountry] = @BillingAddressCountry,
		[ShippingAddressStreet] = @ShippingAddressStreet,
		[ShippingAddressCity] = @ShippingAddressCity,
		[ShippingAddressRegion] = @ShippingAddressRegion,
		[ShippingAddressPostalCode] = @ShippingAddressPostalCode,
		[ShippingAddressCountry] = @ShippingAddressCountry,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = [dbo].[GetCurrentUserId]()
	where
		[Id] = @Id;

	return 0;
end