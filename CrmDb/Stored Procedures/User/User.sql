CREATE TABLE [dbo].[User]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,

	[FirstName] nvarchar(64) null,
	[MiddleName] nvarchar(64) null,
	[LastName] nvarchar(64) null,

	[WindowsIdentity] nvarchar(128) null,
	[SqlIdentity] nvarchar(128) null,
	[UserName] varchar(128) null,
	[PasswordHash] binary(256),

    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null
)
