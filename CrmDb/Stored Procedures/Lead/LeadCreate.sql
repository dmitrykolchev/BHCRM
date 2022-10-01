create procedure [dbo].[LeadCreate]
	@FileAs TName,
	@AssignedToEmployeeId TIdentifier,
	@FirstName nvarchar(64),
	@MiddleName nvarchar(64),
	@LastName nvarchar(64),
	@Title nvarchar(128),
	@Department nvarchar(128),
	@AccountName nvarchar(128),
	@LeadSourceId TIdentifier,
	@LeadSourceDescription nvarchar(512),
	@StatusDescription nvarchar(512),
	@BusinessPhone varchar(128),
	@MobilePhone varchar(128),
	@HomePhone varchar(128),
	@OtherPhone varchar(128),
	@Fax varchar(128),
	@Email varchar(128),
	@OtherEmail varchar(128),
	@WebSite varchar(128),
	@DontCall bit,
	@EmailOptOut bit,
	@InvalidEmail bit,
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
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int, @State TState;

	set @UserId = [dbo].[GetCurrentUserId]();

	if @AssignedToEmployeeId is not null
		set @State = 1;
	else
		set @State = 2;

	insert into [dbo].[Lead]
		([State],
		[FileAs], [AssignedToEmployeeId], [FirstName], [MiddleName], [LastName], [Title], [Department], [AccountName], [LeadSourceId], [LeadSourceDescription], [StatusDescription], [BusinessPhone], [MobilePhone], [HomePhone], [OtherPhone], [Fax], [Email], [OtherEmail], [WebSite], [DontCall], [EmailOptOut], [InvalidEmail], [PrimaryAddressStreet], [PrimaryAddressCity], [PrimaryAddressRegion], [PrimaryAddressPostalCode], [PrimaryAddressCountry], [AlternateAddressStreet], [AlternateAddressCity], [AlternateAddressRegion], [AlternateAddressPostalCode], [AlternateAddressCountry], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(@State,
		@FileAs, @AssignedToEmployeeId, @FirstName, @MiddleName, @LastName, @Title, @Department, @AccountName, @LeadSourceId, @LeadSourceDescription, @StatusDescription, @BusinessPhone, @MobilePhone, @HomePhone, @OtherPhone, @Fax, @Email, @OtherEmail, @WebSite, @DontCall, @EmailOptOut, @InvalidEmail, @PrimaryAddressStreet, @PrimaryAddressCity, @PrimaryAddressRegion, @PrimaryAddressPostalCode, @PrimaryAddressCountry, @AlternateAddressStreet, @AlternateAddressCity, @AlternateAddressRegion, @AlternateAddressPostalCode, @AlternateAddressCountry, @Comments,
		getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[LeadGet] @Id;

	return 0;
end
