create procedure [dbo].[ReminderUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@StartDate date,
			@DueDate date,
			@ReminderTime datetime,
			@UserId TIdentifier,
			@DocumentTypeId TIdentifier,
			@DocumentId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@DueDate = T.c.value('@DueDate', 'date'),
		@ReminderTime = T.c.value('@ReminderTime', 'datetime'),
		@UserId = T.c.value('@UserId', 'TIdentifier'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'TIdentifier'),
		@DocumentId = T.c.value('@DocumentId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Reminder') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Reminder]
	set
		[FileAs] = @FileAs,
		[StartDate] = @StartDate,
		[DueDate] = @DueDate,
		[ReminderTime] = @ReminderTime,
		[UserId] = @UserId,
		[DocumentTypeId] = @DocumentTypeId,
		[DocumentId] = @DocumentId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
