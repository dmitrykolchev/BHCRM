create procedure [dbo].[DocumentStateLogBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @DocumentId TIdentifier, @Presentation varchar(256), @DocumentTypeId int, @ToState TState, @FromState TState;

	select
		@DocumentId = T.c.value('DocumentId[1]', 'TIdentifier'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'int'),
		@FromState = T.c.value('FromState[1]', 'TState'),
		@ToState = T.c.value('ToState[1]', 'TState')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		cast(1 as tinyint) as [State],
		[DocumentTypeId],
		[DocumentId],
		[FromState],
		[ToState],
		[Comments],
		[Data],
		[Created],
		[CreatedBy]
	from
		[dbo].[DocumentStateLog]
	where
		(@DocumentId is null or [DocumentId] = @DocumentId)
	and
		(@DocumentTypeId is null or [DocumentTypeId] = @DocumentTypeId)
	and
		(@FromState is null or [FromState] = @FromState)
	and
		(@ToState is null or [ToState] = @ToState);

	return 0;
end
