create procedure [dbo].[SecuritySchemeUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('SecurityScheme') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[SecurityScheme]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

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
