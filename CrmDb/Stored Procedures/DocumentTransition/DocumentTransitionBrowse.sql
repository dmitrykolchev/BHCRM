create procedure [dbo].[DocumentTransitionBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @DocumentTypeId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[DocumentTypeId],
		[FromState],
		[ToState],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentTransition]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@DocumentTypeId is null or [DocumentTypeId] = @DocumentTypeId);


	return 0;
end
