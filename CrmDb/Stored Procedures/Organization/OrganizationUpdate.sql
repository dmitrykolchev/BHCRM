create procedure [dbo].[OrganizationUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier,
			@FileAs TName,
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
			@Comments nvarchar(max),
			@RowVersion timestamp

	select
		@Id = T.c.value('@Id', 'int'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from	
		@xml.nodes('Organization') as T(c);


	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Account]
	set
		[FileAs] = @FileAs,
		[FullName] = @FullName,
		[MemberOfAccountId] = @MemberOfAccountId,
		[AccountTypeId] = @AccountTypeId | 1,
		[Phone] = @Phone,
		[OtherPhone] = @OtherPhone,
		[Fax] = @Fax,
		[Email] = @Email,
		[OtherEmail] = @OtherEmail,
		[WebSite] = @WebSite,
		[ProjectTemplateId] = @ProjectTemplateId,
		[ExecutiveId] = @ExecutiveId,
		[AccountantId] = @AccountantId,
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
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [RowVersion] = @RowVersion;

	exec [dbo].[OrganizationGet] @Id;

	return 0;
end
