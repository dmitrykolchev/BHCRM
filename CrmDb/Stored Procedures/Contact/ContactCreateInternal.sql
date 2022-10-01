create procedure [dbo].[ContactCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@ContactGroupId TIdentifier,
			@ContactRoleId TIdentifier, 
			@AssignedToEmployeeId TIdentifier,
			@FirstName nvarchar(64),
			@MiddleName nvarchar(64),
			@LastName nvarchar(64),
			@AccountId TIdentifier,
			@ReportsToEmployeeId TIdentifier,
			@LeadSourceId TIdentifier,
			@Title nvarchar(128),
			@Department nvarchar(128),
			@BirthDate date,
			@Gender tinyint,
			@BusinessPhone varchar(128),
			@MobilePhone varchar(128),
			@HomePhone varchar(128),
			@OtherPhone varchar(128),
			@Fax varchar(128),
			@Email varchar(128),
			@OtherEmail varchar(128),
			@Assistant nvarchar(128),
			@AssistantPhone varchar(128),
			@PrimaryAddressStreet nvarchar(256),
			@PrimaryAddressCity nvarchar(64),
			@PrimaryAddressRegion nvarchar(64),
			@PrimaryAddressPostalCode nvarchar(10),
			@PrimaryAddressCountry nvarchar(64),
			@AlternateAddressStreet nvarchar(256),
			@AlternateAddressCity nvarchar(64),
			@AlternateAddressRegion nvarchar(64),
			@AlternateAddressPostalCode nvarchar(10),
			@AlternateAddressCountry nvarchar(64),
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ContactGroupId = T.c.value('@ContactGroupId', 'TIdentifier'),
		@ContactRoleId = T.c.value('@ContactRoleId', 'TIdentifier'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'TIdentifier'),
		@FirstName = T.c.value('@FirstName', 'nvarchar(64)'),
		@MiddleName = T.c.value('@MiddleName', 'nvarchar(64)'),
		@LastName = T.c.value('@LastName', 'nvarchar(64)'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@ReportsToEmployeeId = T.c.value('@ReportsToEmployeeId', 'TIdentifier'),
		@LeadSourceId = T.c.value('@LeadSourceId', 'TIdentifier'),
		@Title = T.c.value('@Title', 'nvarchar(128)'),
		@Department = T.c.value('@Department', 'nvarchar(128)'),
		@BirthDate = T.c.value('@BirthDate', 'date'),
		@Gender = T.c.value('@Gender', 'tinyint'),
		@BusinessPhone = T.c.value('@BusinessPhone', 'varchar(128)'),
		@MobilePhone = T.c.value('@MobilePhone', 'varchar(128)'),
		@HomePhone = T.c.value('@HomePhone', 'varchar(128)'),
		@OtherPhone = T.c.value('@OtherPhone', 'varchar(128)'),
		@Fax = T.c.value('@Fax', 'varchar(128)'),
		@Email = T.c.value('@Email', 'varchar(128)'),
		@OtherEmail = T.c.value('@OtherEmail', 'varchar(128)'),
		@Assistant = T.c.value('@Assistant', 'nvarchar(128)'),
		@AssistantPhone = T.c.value('@AssistantPhone', 'varchar(128)'),
		@PrimaryAddressStreet = T.c.value('@PrimaryAddressStreet', 'nvarchar(256)'),
		@PrimaryAddressCity = T.c.value('@PrimaryAddressCity', 'nvarchar(64)'),
		@PrimaryAddressRegion = T.c.value('@PrimaryAddressRegion', 'nvarchar(64)'),
		@PrimaryAddressPostalCode = T.c.value('@PrimaryAddressPostalCode', 'nvarchar(10)'),
		@PrimaryAddressCountry = T.c.value('@PrimaryAddressCountry', 'nvarchar(64)'),
		@AlternateAddressStreet = T.c.value('@AlternateAddressStreet', 'nvarchar(256)'),
		@AlternateAddressCity = T.c.value('@AlternateAddressCity', 'nvarchar(64)'),
		@AlternateAddressRegion = T.c.value('@AlternateAddressRegion', 'nvarchar(64)'),
		@AlternateAddressPostalCode = T.c.value('@AlternateAddressPostalCode', 'nvarchar(10)'),
		@AlternateAddressCountry = T.c.value('@AlternateAddressCountry', 'nvarchar(64)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Contact') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Employee]
		([State], [IsEmployee], [FileAs], [ContactGroupId], [ContactRoleId], [AssignedToEmployeeId], [FirstName], [MiddleName], [LastName], [AccountId],
		[ReportsToEmployeeId], [LeadSourceId], [Title], [Department], [BirthDate], [Gender],
		[BusinessPhone], [MobilePhone], [HomePhone], [OtherPhone], [Fax], [Email], [OtherEmail],
		[Assistant], [AssistantPhone], [PrimaryAddressStreet], [PrimaryAddressCity], [PrimaryAddressRegion],
		[PrimaryAddressPostalCode], [PrimaryAddressCountry], [AlternateAddressStreet],
		[AlternateAddressCity], [AlternateAddressRegion], [AlternateAddressPostalCode],
		[AlternateAddressCountry], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 0, @FileAs, @ContactGroupId, @ContactRoleId, @AssignedToEmployeeId, @FirstName, @MiddleName, @LastName, @AccountId,
		@ReportsToEmployeeId, @LeadSourceId, @Title, @Department, @BirthDate, @Gender, @BusinessPhone,
		@MobilePhone, @HomePhone, @OtherPhone, @Fax, @Email, @OtherEmail, @Assistant, @AssistantPhone,
		@PrimaryAddressStreet, @PrimaryAddressCity, @PrimaryAddressRegion, @PrimaryAddressPostalCode,
		@PrimaryAddressCountry, @AlternateAddressStreet, @AlternateAddressCity, @AlternateAddressRegion,
		@AlternateAddressPostalCode, @AlternateAddressCountry, @Comments, getdate(), @UserId, getdate(),
		@UserId);

	set @Id = scope_identity();

	return 0;
end
