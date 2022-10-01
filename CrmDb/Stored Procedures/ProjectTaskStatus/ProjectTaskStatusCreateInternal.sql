create procedure [dbo].[ProjectTaskStatusCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Color int,
			@Complete decimal(4,2),
			@ProjectTaskState TState,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Color = T.c.value('@Color', 'int'),
		@Complete = T.c.value('@Complete', 'decimal(4,2)'),
		@ProjectTaskState = T.c.value('@ProjectTaskState', 'TState'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ProjectTaskStatus') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProjectTaskStatus]
		([State], [FileAs], [Color], [Complete], [ProjectTaskState], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Color, @Complete, @ProjectTaskState, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
