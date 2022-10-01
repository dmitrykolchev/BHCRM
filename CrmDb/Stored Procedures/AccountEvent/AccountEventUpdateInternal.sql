create procedure [dbo].[AccountEventUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@AccountEventTypeId TIdentifier,
			@AccountEventDirectionId TIdentifier,
			@Importance TIdentifier,
			@EventStart datetime,
			@EventEnd datetime,
			@AccountId TIdentifier,
			@ContactId TIdentifier,
			@ServiceRequestId TIdentifier,
			@EmployeeId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@AccountEventTypeId = T.c.value('@AccountEventTypeId', 'TIdentifier'),
		@AccountEventDirectionId = T.c.value('@AccountEventDirectionId', 'TIdentifier'),
		@Importance = T.c.value('@Importance', 'TIdentifier'),
		@EventStart = T.c.value('@EventStart', 'datetime'),
		@EventEnd = T.c.value('@EventEnd', 'datetime'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@ContactId = T.c.value('@ContactId', 'TIdentifier'),
		@ServiceRequestId = T.c.value('@ServiceRequestId', 'TIdentifier'),
		@EmployeeId = T.c.value('@EmployeeId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('AccountEvent') as T(c);
	if @@error <> 0
		return 1;

	declare @UserId int;
	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[AccountEvent]
	set
		[FileAs] = @FileAs,
		[AccountEventTypeId] = @AccountEventTypeId,
		[AccountEventDirectionId] = @AccountEventDirectionId,
		[Importance] = @Importance,
		[EventStart] = @EventStart,
		[EventEnd] = @EventEnd,
		[AccountId] = @AccountId,
		[ContactId] = @ContactId,
		[ServiceRequestId] = @ServiceRequestId,
		[EmployeeId] = @EmployeeId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	return 0;
end
