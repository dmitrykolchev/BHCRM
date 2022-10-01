create function [dbo].[DocumentMetadataGetFn]()
returns xml
as
begin
	declare @metadata table ([Id] int not null);

	insert into @metadata ([Id]) values(1);

	return (select
		(select
			[FileAs] as [Code],
			[Comments] as [MessageText]
		from
			[ErrorMessage] as [Message]
		for xml auto, binary base64, type),
		(select
			[FileAs], 
			[DocumentElement],
			[SchemaName],
			[ProcedureName],
			[Comments]
		from
			[DataQuery]
		for xml auto, binary base64, type),
		(select
			[Code],
			[FileAs],
			[Comments]
		from
			[AccessRight] as [Right]
		for xml auto, binary base64, type),
		(select
			[Code],
			[FileAs],
			[Comments],
			(select 
				(select [Code] from [AccessRight] where [Id] = [Access].[AccessRightId]) as [Right]
			from
				[ApplicationRoleAccessRight] as [Access]
			where
				[Access].[ApplicationRoleId] = [Role].[Id]
			for xml auto, binary base64, type)
		from
			[ApplicationRole] as [Role]
		for xml auto, binary base64, type),
		(select 
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
			[Description],
			[SupportsTransitionTemplates],
			(select
				[State],
				[OrdinalPosition],
				[Name],
				[Caption],
				[OverlayImage],
				[Description]
			from
				[DocumentState] as [State]
			where
				[State].[DocumentTypeId] = [DocumentType].[Id]
			for xml auto, binary base64, type),
			(select
				[FileAs],
				[FromState],
				[ToState],
				[Comments],
				(select
					(select [Code] from [ApplicationRole] where [ApplicationRole].[Id] = [ApplicationRoleId]) as [Role]
				from
					[DocumentTransitionAccess] as [Access]
				where
					[Access].[DocumentTransitionId] = [Transition].[Id]
				for xml auto, type)
			from
				[DocumentTransition] as [Transition]
			where
				[Transition].[DocumentTypeId] = [DocumentType].[Id]
			for xml auto, binary base64, type),
			(select
				[State],
				[Code],
				[FileAs],
				[ReportPath],
				[Comments]
			from
				[DocumentReport] as [Report]
			where
				[DocumentTypeId] = [DocumentType].[Id]
			for xml auto, binary base64, type)
		from 
			[DocumentType]
		for xml auto, binary base64, type)
	from
		@metadata as [Metadata]
	for xml auto, binary base64);
end;