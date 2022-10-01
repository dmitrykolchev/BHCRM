create procedure [dbo].[CurrentUserCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@FirstName nvarchar(64),
			@MiddleName nvarchar(64),
			@LastName nvarchar(64),
			@WindowsIdentity nvarchar(128),
			@SqlIdentity nvarchar(128),
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@FirstName = T.c.value('@FirstName', 'nvarchar(64)'),
		@MiddleName = T.c.value('@MiddleName', 'nvarchar(64)'),
		@LastName = T.c.value('@LastName', 'nvarchar(64)'),
		@WindowsIdentity = T.c.value('@WindowsIdentity', 'nvarchar(128)'),
		@SqlIdentity = T.c.value('@SqlIdentity', 'nvarchar(128)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('CurrentUser') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[CurrentUser]
		([State], [FileAs], [FirstName], [MiddleName], [LastName], [WindowsIdentity], [SqlIdentity],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @FirstName, @MiddleName, @LastName, @WindowsIdentity, @SqlIdentity, @Comments,
		getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
