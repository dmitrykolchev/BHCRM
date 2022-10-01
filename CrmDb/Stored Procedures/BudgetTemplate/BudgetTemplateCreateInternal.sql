create procedure [dbo].[BudgetTemplateCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@ServiceRequestTypeId TIdentifier,
			@ServiceLevelId TIdentifier,
			@AmountOfPersons int,
			@EventDuration int,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ServiceRequestTypeId = T.c.value('@ServiceRequestTypeId', 'TIdentifier'),
		@ServiceLevelId = T.c.value('@ServiceLevelId', 'TIdentifier'),
		@AmountOfPersons = T.c.value('@AmountOfPersons', 'int'),
		@EventDuration = T.c.value('@EventDuration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('BudgetTemplate') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[BudgetTemplate]
		([State], [FileAs], [ServiceRequestTypeId], [ServiceLevelId], [AmountOfPersons], [EventDuration], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @ServiceRequestTypeId, @ServiceLevelId, @AmountOfPersons, @EventDuration, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	insert into [dbo].[BudgetTemplateLine]
		([BudgetTemplateId], [BudgetItemId], [StandardValue])
	select
		@Id,
		[Id],
		null
	from
		[dbo].[BudgetItem]
	where
		[BudgetItemGroupId] in (1, 2) and [State] = 1;

	if @@error <> 0
		return 1;

	return 0;
end
