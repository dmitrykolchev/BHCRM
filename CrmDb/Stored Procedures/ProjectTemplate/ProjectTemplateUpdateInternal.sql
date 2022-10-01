create procedure [dbo].[ProjectTemplateUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@ProjectTypeId TIdentifier,
			@Duration int,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectTypeId = T.c.value('@ProjectTypeId', 'TIdentifier'),
		@Duration = T.c.value('@Duration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ProjectTemplate') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProjectTemplate]
	set
		[FileAs] = @FileAs,
		[ProjectTypeId] = @ProjectTypeId,
		[Duration] = @Duration,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
