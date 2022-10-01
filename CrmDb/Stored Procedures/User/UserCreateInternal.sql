create procedure [dbo].[UserCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@FirstName nvarchar(64),
			@MiddleName nvarchar(64),
			@LastName nvarchar(64),
			@WindowsIdentity nvarchar(128),
			@SqlIdentity nvarchar(128),
			@UserName varchar(128),
			@PasswordHash binary(256),
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@FirstName = T.c.value('@FirstName', 'nvarchar(64)'),
		@MiddleName = T.c.value('@MiddleName', 'nvarchar(64)'),
		@LastName = T.c.value('@LastName', 'nvarchar(64)'),
		@WindowsIdentity = T.c.value('@WindowsIdentity', 'nvarchar(128)'),
		@SqlIdentity = T.c.value('@SqlIdentity', 'nvarchar(128)'),
		@UserName = T.c.value('@UserName', 'varchar(128)'),
		@PasswordHash = T.c.value('@PasswordHash', 'binary(256)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('User') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[User]
		([State], [FileAs], [FirstName], [MiddleName], [LastName], [WindowsIdentity], [SqlIdentity],
		[UserName], [PasswordHash], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @FirstName, @MiddleName, @LastName, @WindowsIdentity, @SqlIdentity, @UserName,
		@PasswordHash, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[UserApplicationRole]
		([UserId], [ApplicationRoleId])
	select
		@Id,
		T.c.value('@ApplicationRoleId', 'int')
	from	
		@xml.nodes('User/Roles/UserApplicationRole') as T(c)
	if @@error <> 0
		return 1;


	return 0;
end
