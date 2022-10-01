create procedure [dbo].[EmployeeUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@AccountId TIdentifier,
			@TradeMarkId TIdentifier,
			@PositionId TIdentifier,
			@ContactGroupId TIdentifier,
			@ContactRoleId TIdentifier,
			@ReportsToEmployeeId TIdentifier,
			@DivisionId TIdentifier,
			@AssignedToEmployeeId TIdentifier,
			@LeadSourceId TIdentifier,
			@Title nvarchar(128),
			@Department nvarchar(128),
			@FirstName nvarchar(64),
			@MiddleName nvarchar(64),
			@LastName nvarchar(64),
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
			@UserId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@TradeMarkId = T.c.value('@TradeMarkId', 'TIdentifier'),
		@PositionId = T.c.value('@PositionId', 'TIdentifier'),
		@ContactGroupId = T.c.value('@ContactGroupId', 'TIdentifier'),
		@ContactRoleId = T.c.value('@ContactRoleId', 'TIdentifier'),
		@ReportsToEmployeeId = T.c.value('@ReportsToEmployeeId', 'TIdentifier'),
		@DivisionId = T.c.value('@DivisionId', 'TIdentifier'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'TIdentifier'),
		@LeadSourceId = T.c.value('@LeadSourceId', 'TIdentifier'),
		@Title = T.c.value('@Title', 'nvarchar(128)'),
		@Department = T.c.value('@Department', 'nvarchar(128)'),
		@FirstName = T.c.value('@FirstName', 'nvarchar(64)'),
		@MiddleName = T.c.value('@MiddleName', 'nvarchar(64)'),
		@LastName = T.c.value('@LastName', 'nvarchar(64)'),
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
		@UserId = T.c.value('@UserId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Employee') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int, @EmployeeAccountId TIdentifier;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Employee]
	set
		[FileAs] = @FileAs,
		[AccountId] = @AccountId,
		[TradeMarkId] = @TradeMarkId,
		[PositionId] = @PositionId,
		[ContactGroupId] = @ContactGroupId,
		[ContactRoleId] = @ContactRoleId,
		[ReportsToEmployeeId] = @ReportsToEmployeeId,
		[DivisionId] = @DivisionId,
		[AssignedToEmployeeId] = @AssignedToEmployeeId,
		[LeadSourceId] = @LeadSourceId,
		[Title] = @Title,
		[Department] = @Department,
		[FirstName] = @FirstName,
		[MiddleName] = @MiddleName,
		[LastName] = @LastName,
		[BirthDate] = @BirthDate,
		[Gender] = @Gender,
		[BusinessPhone] = @BusinessPhone,
		[MobilePhone] = @MobilePhone,
		[HomePhone] = @HomePhone,
		[OtherPhone] = @OtherPhone,
		[Fax] = @Fax,
		[Email] = @Email,
		[OtherEmail] = @OtherEmail,
		[Assistant] = @Assistant,
		[AssistantPhone] = @AssistantPhone,
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
		[UserId] = @UserId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId,
		@EmployeeAccountId = [EmployeeAccountId]
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	update [dbo].[Account]
	set
		[FileAs] = @FileAs,
		[AccountTypeId] = 0x08,
		[TradeMarkId] = @TradeMarkId,
		[Phone] = @BusinessPhone,
		[OtherPhone] = @MobilePhone,
		[Email] = @Email,
		[OtherEmail] = @OtherEmail,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @EmployeeAccountId;
	if @@error <> 0
		return 1;

	delete [dbo].[EmployeeSalary] where [EmployeeId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[EmployeeSalary]
		([EmployeeId], [Value], [CashValue], [ActiveFrom])
	select
		@Id,
		T.c.value('@Value', 'TMoney'),				
		T.c.value('@CashValue', 'TMoney'),
		T.c.value('@ActiveFrom', 'date')
	from
		@xml.nodes('Employee/Salaries/EmployeeSalary') as T(c);
	if @@error <> 0
		return 1;

	return 0;
end
