create procedure [dbo].[PresentationNodeExport]
as
begin
	set nocount on;
	
	select
		[PresentationNode].[Id],
		[PresentationNode].[State],
		[PresentationNode].[FileAs],
		[PresentationNode].[Key],
		[PresentationNode].[DefaultViewId],
		[PresentationNode].[OrdinalPosition],
		[PresentationNode].[ViewControlTypeName],
		[PresentationNode].[Parameter],
		[PresentationNode].[ParentId],
		(select [ClassName] from [DocumentType] where [Id] = [PresentationNode].[DocumentTypeId]) as [ClassName],
		[PresentationNode].[SmallImageData],
		[PresentationNode].[LargeImageData],
		[PresentationNode].[NodeType],
		[PresentationNode].[Comments],
		[PresentationNode].[Created],
		[PresentationNode].[CreatedBy],
		[PresentationNode].[Modified],
		[PresentationNode].[ModifiedBy],
		(select 
			[Code]
		from
			[PresentationNodeApplicationRole] inner join [ApplicationRole]
				on ([PresentationNodeApplicationRole].[ApplicationRoleId] = [ApplicationRole].[Id])
		where
			[PresentationNodeId] = [PresentationNode].[Id]
		for xml auto, type) as [ApplicationRoles]
	from
		[PresentationNode]
	for xml auto, binary base64, root('ArrayOfPresentationNode')

	return 0;
end
