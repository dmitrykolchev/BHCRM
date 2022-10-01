create procedure [dbo].[BudgetTemplateUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@ServiceRequestTypeId TIdentifier,
			@ServiceLevelId TIdentifier,
			@AmountOfPersons int,
			@EventDuration int,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ServiceRequestTypeId = T.c.value('@ServiceRequestTypeId', 'TIdentifier'),
		@ServiceLevelId = T.c.value('@ServiceLevelId', 'TIdentifier'),
		@AmountOfPersons = T.c.value('@AmountOfPersons', 'int'),
		@EventDuration = T.c.value('@EventDuration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('BudgetTemplate') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[BudgetTemplate]
	set
		[FileAs] = @FileAs,
		[ServiceRequestTypeId] = @ServiceRequestTypeId,
		[ServiceLevelId] = @ServiceLevelId,
		[AmountOfPersons] = @AmountOfPersons,
		[EventDuration] = @EventDuration,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
