CREATE TABLE [dbo].[Lead]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[AssignedToEmployeeId] TIdentifier null,

	[FirstName] nvarchar(64) null,
	[MiddleName] nvarchar(64) null,
	[LastName] nvarchar(64) null,
	[Title] nvarchar(128) null,
	[Department] nvarchar(128) null,
	[AccountName] nvarchar(128) null,
	[LeadSourceId] TIdentifier NOT null,
	[LeadSourceDescription] nvarchar(512) null,
	[StatusDescription] nvarchar(512) null,

	[BusinessPhone] varchar(128) null,
	[MobilePhone] varchar(128) null,
	[HomePhone] varchar(128) null,
	[OtherPhone] varchar(128) null,
	[Fax] varchar(128) null,
	[Email] varchar(128) null,
	[OtherEmail] varchar(128) null,
	[WebSite] varchar(128) null,
	
	[DontCall] bit not null,
	[EmailOptOut] bit not null,
	[InvalidEmail] bit not null,
		
	[PrimaryAddressStreet] nvarchar(256) null,
	[PrimaryAddressCity] nvarchar(64) null,
	[PrimaryAddressRegion] nvarchar(64) null,
	[PrimaryAddressPostalCode] nvarchar(10) null,
	[PrimaryAddressCountry] nvarchar(64) null,

	[AlternateAddressStreet] nvarchar(256) null,
	[AlternateAddressCity] nvarchar(64) null,
	[AlternateAddressRegion] nvarchar(64) null,
	[AlternateAddressPostalCode] nvarchar(10) null,
	[AlternateAddressCountry] nvarchar(64) null,

	[Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_Lead_Employee] FOREIGN KEY ([AssignedToEmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_Lead_LeadSource] FOREIGN KEY ([LeadSourceId]) REFERENCES [LeadSource]([Id])
)
