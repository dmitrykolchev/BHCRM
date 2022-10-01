create procedure [dbo].[OrganizationCreate] @xml xml
as
begin
	set nocount on;

	declare @FileAs TName,
			@FullName nvarchar(1024),
			@MemberOfAccountId TIdentifier,
			@AccountTypeId TIdentifier,
			@Phone varchar(128),
			@OtherPhone varchar(128),
			@Fax varchar(128),
			@Email varchar(128),
			@OtherEmail varchar(128),
			@WebSite varchar(128),
			@ProjectTemplateId TIdentifier,
			@ExecutiveId TIdentifier,
			@AccountantId TIdentifier,
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
			@Comments nvarchar(max)

	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@FullName = T.c.value('@FullName', 'nvarchar(1024)'),
		@MemberOfAccountId = T.c.value('@MemberOfAccountId', 'int'),
		@AccountTypeId = T.c.value('@AccountTypeId', 'int'),
		@ProjectTemplateId = T.c.value('@ProjectTemplateId', 'TIdentifier'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from	
		@xml.nodes('Organization') as T(c);


	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Account]
		([State], 
		[FileAs], [FullName], [MemberOfAccountId], [AccountTypeId], [Phone], [OtherPhone], [Fax], [Email], [OtherEmail], [WebSite], [ProjectTemplateId], 
		[ExecutiveId], [AccountantId], [BillingAddressStreet], [BillingAddressCity], [BillingAddressRegion], [BillingAddressPostalCode], [BillingAddressCountry], 
		[ShippingAddressStreet], [ShippingAddressCity], [ShippingAddressRegion], [ShippingAddressPostalCode], [ShippingAddressCountry], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 
		@FileAs, @FullName, @MemberOfAccountId, @AccountTypeId | 1, @Phone, @OtherPhone, @Fax, @Email, @OtherEmail, @WebSite, @ProjectTemplateId,
		@ExecutiveId, @AccountantId, @BillingAddressStreet, @BillingAddressCity, @BillingAddressRegion, @BillingAddressPostalCode, @BillingAddressCountry, 
		@ShippingAddressStreet, @ShippingAddressCity, @ShippingAddressRegion, @ShippingAddressPostalCode, @ShippingAddressCountry, @Comments,
		getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[OrganizationGet] @Id;

	return 0;
end
