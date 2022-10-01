create procedure [dbo].[ProjectTaskStatusUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Color int,
			@Complete decimal(4,2),
			@ProjectTaskState TState,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Color = T.c.value('@Color', 'int'),
		@Complete = T.c.value('@Complete', 'decimal(4,2)'),
		@ProjectTaskState = T.c.value('@ProjectTaskState', 'TState'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ProjectTaskStatus') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProjectTaskStatus]
	set
		[FileAs] = @FileAs,
		[Color] = @Color,
		[Complete] = @Complete,
		[ProjectTaskState] = @ProjectTaskState,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
