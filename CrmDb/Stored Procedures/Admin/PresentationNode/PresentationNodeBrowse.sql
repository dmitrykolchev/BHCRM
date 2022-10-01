create procedure [dbo].[PresentationNodeBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Presentation varchar(256), @ParentId TIdentifier, @DocumentTypeId int, @AllNodeTypes bit, @AllNodes bit;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@AllNodeTypes = T.c.value('AllNodeTypes[1]', 'bit'),
		@AllNodes = T.c.value('AllNodes[1]', 'bit'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@ParentId = T.c.value('ParentId[1]', 'TIdentifier'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	if @AllNodes = 1
	begin
		select
			[PresentationNode].[Id],
			[PresentationNode].[State],
			[PresentationNode].[FileAs],
			[PresentationNode].[Key],
			[PresentationNode].[DefaultViewId],
			[PresentationNode].[ViewControlTypeName],
			[PresentationNode].[OrdinalPosition],
			[PresentationNode].[Parameter],
			[PresentationNode].[ParentId],
			[PresentationNode].[DocumentTypeId],
			[PresentationNode].[SmallImageData],
			[PresentationNode].[LargeImageData],
			[PresentationNode].[NodeType],
			[PresentationNode].[Comments],
			[PresentationNode].[Created],
			[PresentationNode].[CreatedBy],
			[PresentationNode].[Modified],
			[PresentationNode].[ModifiedBy],
			[PresentationNode].[RowVersion]
		from
			[dbo].[PresentationNode] 
		where
			(@ParentId is null or [PresentationNode].[ParentId] = @ParentId)
			and
			(@AllNodeTypes = 1 or [NodeType] in (select T.c.value('.[1]', 'int') from @filter.nodes('Filter/NodeType') as T(c)))
			and 
			(@AllStates = 1 or [PresentationNode].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));
	end
	else 
	begin
		with [A] ([Id], [ParentId], [DocumentTypeId]) as 
		(
			select
				[Id],
				[ParentId], 
				[DocumentTypeId]
			from
				[PresentationNode]
			where
				[ParentId] is null
			and
				((@DocumentTypeId is null and [DocumentTypeId] is null) or ([DocumentTypeId] = @DocumentTypeId))
			union all
			select
				[PresentationNode].[Id],
				[PresentationNode].[ParentId], 
				[PresentationNode].[DocumentTypeId]
			from
				[PresentationNode] inner join [A]
					on ([PresentationNode].[ParentId] = [A].[Id])
		)
		select
			[PresentationNode].[Id],
			[PresentationNode].[State],
			[PresentationNode].[FileAs],
			[PresentationNode].[Key],
			[PresentationNode].[DefaultViewId],
			[PresentationNode].[ViewControlTypeName],
			[PresentationNode].[OrdinalPosition],
			[PresentationNode].[Parameter],
			[PresentationNode].[ParentId],
			[PresentationNode].[DocumentTypeId],
			[PresentationNode].[SmallImageData],
			[PresentationNode].[LargeImageData],
			[PresentationNode].[NodeType],
			[PresentationNode].[Comments],
			[PresentationNode].[Created],
			[PresentationNode].[CreatedBy],
			[PresentationNode].[Modified],
			[PresentationNode].[ModifiedBy],
			[PresentationNode].[RowVersion]
		from
			[dbo].[PresentationNode] inner join [A]
				on ([PresentationNode].[Id] = [A].[Id])
		where
			(@ParentId is null or [PresentationNode].[ParentId] = @ParentId)
			and
			(@AllNodeTypes = 1 or [NodeType] in (select T.c.value('.[1]', 'int') from @filter.nodes('Filter/NodeType') as T(c)))
			and 
			(@AllStates = 1 or [PresentationNode].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));
	end

	return 0;
end
