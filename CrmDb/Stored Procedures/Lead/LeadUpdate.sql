create procedure [dbo].[LeadUpdate]
	@Id TIdentifier,
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
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int, @State TState, @PrevAssignedToEmployeeId TIdentifier;

	set @UserId = [dbo].[GetCurrentUserId]();

	select
		@State = [State],
		@PrevAssignedToEmployeeId = [AssignedToEmployeeId]
	from
		[dbo].[Lead]
	where
		[Id] = @Id;

	if @State = 1 and @AssignedToEmployeeId is not null
		set @State = 2;

	update [dbo].[Lead]
	set
		[State] = @State,
		[FileAs] = @FileAs,
		[AssignedToEmployeeId] = @AssignedToEmployeeId,
		[FirstName] = @FirstName,
		[MiddleName] = @MiddleName,
		[LastName] = @LastName,
		[Title] = @Title,
		[Department] = @Department,
		[AccountName] = @AccountName,
		[LeadSourceId] = @LeadSourceId,
		[LeadSourceDescription] = @LeadSourceDescription,
		[StatusDescription] = @StatusDescription,
		[BusinessPhone] = @BusinessPhone,
		[MobilePhone] = @MobilePhone,
		[HomePhone] = @HomePhone,
		[OtherPhone] = @OtherPhone,
		[Fax] = @Fax,
		[Email] = @Email,
		[OtherEmail] = @OtherEmail,
		[WebSite] = @WebSite,
		[DontCall] = @DontCall,
		[EmailOptOut] = @EmailOptOut,
		[InvalidEmail] = @InvalidEmail,
		[PrimaryAddressStreet] = @PrimaryAddressStreet,
		[PrimaryAddressCity] = @PrimaryAddressCity,
		[PrimaryAddressRegion] = @PrimaryAddressRegion,
		[PrimaryAddressPostalCode] = @PrimaryAddressPostalCode,
		[PrimaryAddressCountry] = @PrimaryAddressCountry,
		[AlternateAddressStreet] = @AlternateAddressStreet,
		[AlternateAddressCity] = @AlternateAddressCity,
		[AlternateAddressRegion] = @AlternateAddressRegion,
		[AlternateAddressPostalCode] = @AlternateAddressPostalCode,
		[AlternateAddressCountry] = @AlternateAddressCountry,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [RowVersion] = @RowVersion;

	exec [dbo].[LeadGet] @Id;

	return 0;
end
