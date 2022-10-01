create procedure [dbo].[AccessRightCreate] @xml xml
as
begin
	set nocount on;
	declare @Code varchar(256),
			@FileAs TName,
			@Comments nvarchar(max)

	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@Code = T.c.value('@Code', 'varchar(256)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from	
		@xml.nodes('AccessRight') as T(c);

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	begin transaction;

	insert into [dbo].[AccessRight]
		([State], [Code], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @Code, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	set @Id = scope_identity();

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
