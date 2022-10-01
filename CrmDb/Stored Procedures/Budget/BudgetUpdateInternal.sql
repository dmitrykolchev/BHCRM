create procedure [dbo].[BudgetUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ServiceRequestId TIdentifier,
			@BudgetTemplateId TIdentifier,
			@AmountOfGuests int,
			@EventDuration int,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ServiceRequestId = T.c.value('@ServiceRequestId', 'TIdentifier'),
		@BudgetTemplateId = T.c.value('@BudgetTemplateId', 'TIdentifier'),
		@AmountOfGuests = T.c.value('@AmountOfGuests', 'int'),
		@EventDuration = T.c.value('@EventDuration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Budget') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Budget]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[ServiceRequestId] = @ServiceRequestId,
		[BudgetTemplateId] = @BudgetTemplateId,
		[AmountOfGuests] = @AmountOfGuests,
		[EventDuration] = @EventDuration,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	declare @result int;
	exec @result = [dbo].[BudgetRecalculate] @Id;
	if @@error <> 0 or @result <> 0
		return 1;
	return 0;
end
