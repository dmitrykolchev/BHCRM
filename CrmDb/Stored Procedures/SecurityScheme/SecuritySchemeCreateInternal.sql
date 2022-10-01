create procedure [dbo].[SecuritySchemeCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('SecurityScheme') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[SecurityScheme]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	with [Role] ([Code], [FileAs], [Comments]) as 
	(
		select
			T.c.value('@Code', 'varchar(256)'),
			T.c.value('@FileAs', 'TName'),
			T.c.value('@Comments', 'nvarchar(max)')
		from
			@xml.nodes('SecurityScheme/Roles/ApplicationRole') as T(c)
	)
	update [dbo].[ApplicationRole]
	set
		[FileAs] = [R].[FileAs]
	from
		[dbo].[ApplicationRole] as [A] inner join [Role] as [R]
			on ([A].[Code] = [R].[Code]);

	if @@error <> 0
		return 1;

	with [Role] ([Code], [FileAs], [Comments]) as 
	(
		select
			T.c.value('@Code', 'varchar(256)'),
			T.c.value('@FileAs', 'TName'),
			T.c.value('@Comments', 'nvarchar(max)')
		from
			@xml.nodes('SecurityScheme/Roles/ApplicationRole') as T(c)
	)
	insert [dbo].[ApplicationRole]
		([State], [Code], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		1,
		[Code],
		[FileAs],
		[Comments],
		getdate(), 
		1, 
		getdate(), 
		1
	from
		[Role]
	where
		[Code] not in (select [Code] from [dbo].[ApplicationRole]);
	if @@error <> 0
		return 1;

	return 0;
end
