create procedure [dbo].[DocumentTransitionCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@DocumentTypeId int,
			@FromState TState,
			@ToState TState,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@FromState = T.c.value('@FromState', 'TState'),
		@ToState = T.c.value('@ToState', 'TState'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DocumentTransition') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();
	
	insert into [dbo].[DocumentTransition]
		([State], [FileAs], [DocumentTypeId], [FromState], [ToState], [Comments], [Created],
		[CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @DocumentTypeId, @FromState, @ToState, @Comments, getdate(), @UserId,
		getdate(), @UserId);
	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [DocumentTransitionAccess]
		([DocumentTransitionId], [ApplicationRoleId])
	select
		@Id,
		T.c.value('@ApplicationRoleId', 'int')
	from
		@xml.nodes('DocumentTransition/Roles/DocumentTransitionAccess') as T(c);
	if @@error <> 0
		return 1;

	return 0;
end
