create procedure [dbo].[CurrentUserUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@FirstName nvarchar(64),
			@MiddleName nvarchar(64),
			@LastName nvarchar(64),
			@WindowsIdentity nvarchar(128),
			@SqlIdentity nvarchar(128),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@FirstName = T.c.value('@FirstName', 'nvarchar(64)'),
		@MiddleName = T.c.value('@MiddleName', 'nvarchar(64)'),
		@LastName = T.c.value('@LastName', 'nvarchar(64)'),
		@WindowsIdentity = T.c.value('@WindowsIdentity', 'nvarchar(128)'),
		@SqlIdentity = T.c.value('@SqlIdentity', 'nvarchar(128)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('CurrentUser') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[CurrentUser]
	set
		[FileAs] = @FileAs,
		[FirstName] = @FirstName,
		[MiddleName] = @MiddleName,
		[LastName] = @LastName,
		[WindowsIdentity] = @WindowsIdentity,
		[SqlIdentity] = @SqlIdentity,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
