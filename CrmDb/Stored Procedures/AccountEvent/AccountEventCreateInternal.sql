create procedure [dbo].[AccountEventCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('AccountEvent') as T(c);
	if @@error <> 0
		return 1;
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[AccountEvent]
		([State], [FileAs], [AccountEventTypeId], [AccountEventDirectionId], [Importance], [EventStart], [EventEnd],
		[AccountId], [ContactId], [ServiceRequestId], [EmployeeId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @AccountEventTypeId, @AccountEventDirectionId, @Importance, @EventStart, @EventEnd, @AccountId,
		@ContactId, @ServiceRequestId, @EmployeeId, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	return 0;
end
