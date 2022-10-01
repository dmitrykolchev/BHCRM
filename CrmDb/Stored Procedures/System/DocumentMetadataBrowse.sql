create procedure [dbo].[DocumentMetadataBrowse]
as
begin
	select
		[Id],
		[ClassName] + 'View' as [ViewName],
		[ClassName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterType],
		[IsNumbered],
		[Caption],
		[SmallImage],
		[LargeImage],
		[SupportsTransitionTemplates],
		[Description],
		(select	
			[State] as [Value], [OrdinalPosition] as [Ordinal], [Name], [Caption], [OverlayImage], [Description] 
		from 
			[DocumentState] as [State] 
		where
			[DocumentTypeId] = [DocumentType].[Id] 
		order by
			[OrdinalPosition]
		for xml auto, binary base64, type),
		(select
			[Id], [FromState], [ToState], 
			(select [ApplicationRoleId] as [Id] from [DocumentTransitionAccess] as [Role] where [DocumentTransitionId] = [Transition].[Id] for xml auto, type)
		from
			[DocumentTransition] as [Transition]
		where
			[DocumentTypeId] = [DocumentType].[Id] and exists(select * from [DocumentTransitionAccess] where [DocumentTransitionId] = [Transition].[Id])
		for xml auto, type),
		(select 
			[Id], [ViewName], [ClassName], [TableName], [SchemaName], [ClrTypeName], 
			[DataAdapterTypeName], [DataAdapterType], [Caption], [Description] 
		from 
			[DocumentView] as [View]
		where 
			[ClassName] = [DocumentType].[ClassName]
		for xml auto, type)
	from
		[dbo].[DocumentType] as [DocumentType]
	order by
		[ClassName]
	for xml auto, binary base64, root('DocumentMetadata');

	return 0;
end