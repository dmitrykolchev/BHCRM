create procedure [dbo].[PresentationNodeList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @AllNodeTypes bit;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[Key],
		[DefaultViewId],
		[ViewControlTypeName],
		[OrdinalPosition],
		[Parameter],
		[ParentId],
		[DocumentTypeId],
		[SmallImageData],
		[LargeImageData],
		[NodeType]
	from
		[dbo].[PresentationNode]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
