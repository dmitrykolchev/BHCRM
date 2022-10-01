create procedure [dbo].[AccessRightUpdate] @xml xml
as
begin
	set nocount on;
	declare @Id TIdentifier,
			@Code varchar(256),
			@FileAs TName,
			@Comments nvarchar(max),
			@RowVersion timestamp

	select
		@Id = T.c.value('@Id', 'int'),
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@Code = T.c.value('@Code', 'varchar(256)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from	
		@xml.nodes('AccessRight') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	begin transaction;

	update [dbo].[AccessRight]
	set
		[Code] = @Code,
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[ApplicationRoleAccessRight] where [AccessRightId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	insert into [dbo].[ApplicationRoleAccessRight]
		([ApplicationRoleId], [AccessRightId])
	select
		T.c.value('@ApplicationRoleId', 'int'),
		@Id
	from	
		@xml.nodes('AccessRight/Roles/ApplicationRoleAccessRight') as T(c)
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec AccessRightGet @Id;

	return 0;
end
