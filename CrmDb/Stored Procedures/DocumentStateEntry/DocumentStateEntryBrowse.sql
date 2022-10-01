create procedure [dbo].[DocumentStateEntryBrowse] @filter xml
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
		[DocumentTypeId],
		[State],
		[OrdinalPosition],
		[Value],
		[Code],
		[FileAs],
		[OverlayImage],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentStateEntry]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@DocumentTypeId is null or [DocumentTypeId] = @DocumentTypeId);

	return 0;
end
