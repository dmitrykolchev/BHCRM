create procedure [dbo].[DocumentAccessControlListUpdateInternal] @xml xml, @Id TIdentifier out
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
		@xml.nodes('DocumentAccessControlList') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentAccessControlList]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[DocumentGenericRight];
	if @@error <> 0
		return 1;

	insert into [dbo].[DocumentGenericRight]
		([DocumentTypeId], [ApplicationRoleId], [RightFlags])
	select
		T.c.value('@DocumentTypeId', 'int'),
		T.c.value('@ApplicationRoleId', 'int'),
		T.c.value('@RightFlags', 'int')
	from
		@xml.nodes('DocumentAccessControlList/Rights/Right') as T(c)

	if @@error <> 0
		return 1;

	return 0;
end
