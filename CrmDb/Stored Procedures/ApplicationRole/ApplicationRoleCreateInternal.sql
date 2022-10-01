create procedure [dbo].[ApplicationRoleCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code varchar(256),
			@FileAs TName,
			@Comments nvarchar(max);
	select
		@Code = T.c.value('@Code', 'varchar(256)'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ApplicationRole') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ApplicationRole]
		([State], [Code], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @Code, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	return 0;
end
