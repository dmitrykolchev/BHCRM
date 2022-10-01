create procedure [dbo].[DocumentTransitionUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@DocumentTypeId int,
			@FromState TState,
			@ToState TState,
			@AccessRightId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@FromState = T.c.value('@FromState', 'TState'),
		@ToState = T.c.value('@ToState', 'TState'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentTransition') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentTransition]
	set
		[FileAs] = @FileAs,
		[DocumentTypeId] = @DocumentTypeId,
		[FromState] = @FromState,
		[ToState] = @ToState,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	delete [DocumentTransitionAccess] where [DocumentTransitionId] = @Id;
	if @@error <> 0
		return 1;

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
