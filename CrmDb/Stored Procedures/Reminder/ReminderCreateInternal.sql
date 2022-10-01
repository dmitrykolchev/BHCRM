create procedure [dbo].[ReminderCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@DueDate = T.c.value('@DueDate', 'date'),
		@ReminderTime = T.c.value('@ReminderTime', 'datetime'),
		@UserId = T.c.value('@UserId', 'TIdentifier'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'TIdentifier'),
		@DocumentId = T.c.value('@DocumentId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Reminder') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Reminder]
		([State], [FileAs], [StartDate], [DueDate], [ReminderTime], [UserId], [DocumentTypeId], [DocumentId],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @StartDate, @DueDate, @ReminderTime, @UserId, @DocumentTypeId, @DocumentId, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
