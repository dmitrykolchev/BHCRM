create procedure [dbo].[DocumentMetadataImport] @data xml
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[ErrorMessage];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	insert [dbo].[ErrorMessage]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		1,
		T.c.value('@Code', 'TName'),
		T.c.value('@MessageText', 'nvarchar(max)'),
		getdate(), 1, getdate(), 1
	from	
		@data.nodes('Metadata/Message') as T(c);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DataQuery]
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	insert [dbo].[DataQuery]
		([State], [FileAs], [DocumentElement], [SchemaName], [ProcedureName], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		1,
		T.c.value('@FileAs', 'TName'),
		T.c.value('@DocumentElement', 'varchar(256)'),
		T.c.value('@SchemaName', 'varchar(128)'),
		T.c.value('@ProcedureName', 'varchar(128)'),
		T.c.value('@Comments', 'nvarchar(max)'),
		getdate(), 1, getdate(), 1
	from	
		@data.nodes('Metadata/DataQuery') as T(c);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	merge [dbo].[AccessRight] as [target]
	using (	select
				T.c.value('@Code', 'varchar(128)'),
				T.c.value('@FileAs', 'TName')
			from	
				@data.nodes('Metadata/Right') as T(c)) as [source] ([Code], [FileAs])
		on ([target].[Code] = [source].[Code])
	when matched then
		update
		set
			[FileAs] = [source].[FileAs]
	when not matched then
		insert
			([State], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			(1, [source].[Code], [source].[FileAs], getdate(), 1, getdate(), 1);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	
	merge [dbo].[ApplicationRole] as [target]
	using ( select
				T.c.value('@Code', 'varchar(128)'),
				T.c.value('@FileAs', 'TName')
			from	
				@data.nodes('Metadata/Role') as T(c)) as [source] ([Code], [FileAs])
		on ([target].[Code] = [source].[Code])
	when matched then
		update
		set
			[FileAs] = [source].[FileAs]
	when not matched then
		insert
			([State], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			(1, [source].[Code], [source].[FileAs], getdate(), 1, getdate(), 1);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	
	with [T] ([ApplicationRole], [AccessRight]) as
	(
		select
			T.c.value('../@Code', 'varchar(128)'),
			T.c.value('@Right', 'varchar(128)')
		from	
			@data.nodes('Metadata/Role/Access') as T(c)
	)
	merge [dbo].[ApplicationRoleAccessRight] as [target]
	using ( select
				[ApplicationRole].[Id], [AccessRight].[Id]
			from 
				[T] inner join [ApplicationRole]
					on ([T].[ApplicationRole] = [ApplicationRole].[Code])
				inner join [AccessRight]
					on ([T].[AccessRight] = [AccessRight].[Code])) as [source] ([ApplicationRoleId], [AccessRightId])
		on ([target].[ApplicationRoleId] = [source].[ApplicationRoleId] and [target].[AccessRightId] = [source].[AccessRightId])
	when not matched then
		insert 
			([ApplicationRoleId], [AccessRightId])
		values
			([source].[ApplicationRoleId], [source].[AccessRightId]);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	merge [dbo].[DocumentType] as [target]
	using( select
				T.c.value('@ClassName', 'varchar(256)'),
				T.c.value('@TableName', 'nvarchar(128)'),
				T.c.value('@SchemaName', 'nvarchar(128)'),
				T.c.value('@ClrTypeName', 'varchar(1024)'),
				T.c.value('@DataAdapterTypeName', 'varchar(1024)'),
				T.c.value('@DataAdapterType', 'varchar(32)'),
				T.c.value('@IsNumbered', 'bit'),
				T.c.value('@Caption', 'nvarchar(256)'),
				T.c.value('@SmallImage', 'varbinary(max)'),
				T.c.value('@LargeImage', 'varbinary(max)'),
				T.c.value('@Description', 'nvarchar(max)'),
				T.c.value('@SupportsTransitionTemplates', 'bit')
			from	
				@data.nodes('Metadata/DocumentType') as T(c)) as [source] 
					([ClassName], [TableName], [SchemaName], [ClrTypeName], [DataAdapterTypeName], [DataAdapterType], [IsNumbered], 
					 [Caption], [SmallImage], [LargeImage], [Description], [SupportsTransitionTemplates])
		on ([target].[ClassName] = [source].[ClassName])
	when matched then
		update
		set
			[TableName] = [source].[TableName],
			[SchemaName] = [source].[SchemaName],
			[ClrTypeName] = [source].[ClrTypeName],
			[DataAdapterTypeName] = [source].[DataAdapterTypeName],
			[DataAdapterType] = [source].[DataAdapterType],
			[IsNumbered] = [source].[IsNumbered],
			[Caption] = [source].[Caption],
			[SmallImage] = [source].[SmallImage],
			[LargeImage] = [source].[LargeImage],
			[Description] = [source].[Description],
			[SupportsTransitionTemplates] = [source].[SupportsTransitionTemplates]
	when not matched then
		insert
			([ClassName], [TableName], [SchemaName], [ClrTypeName], [DataAdapterTypeName], [DataAdapterType], [IsNumbered], 
			[Caption], [SmallImage], [LargeImage], [Description], [SupportsTransitionTemplates], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			([source].[ClassName], [source].[TableName], [source].[SchemaName], [source].[ClrTypeName], [source].[DataAdapterTypeName], [source].[DataAdapterType], [source].[IsNumbered], 
			 [source].[Caption], [source].[SmallImage], [source].[LargeImage], [source].[Description], [source].[SupportsTransitionTemplates], getdate(), 1, getdate(), 1);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete from [DocumentReport];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	with [T] ([ClassName], [State], [Code], [FileAs], [ReportPath], [Comments]) as
	(
		select
			T.c.value('../@ClassName', 'varchar(256)'),
			T.c.value('@State', 'tinyint'),
			T.c.value('@Code', 'varchar(128)'),
			T.c.value('@FileAs', 'nvarchar(256)'),
			T.c.value('@ReportPath', 'nvarchar(1024)'),
			T.c.value('@Comments', 'nvarchar(max)')
		from	
			@data.nodes('Metadata/DocumentType/Report') as T(c)
	)
	insert into [DocumentReport]
		([State], [Code], [FileAs], [DocumentTypeId], [ReportPath], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		[State],
		[Code],
		[FileAs],
		dbo.GetDocumentTypeId([ClassName]),
		[ReportPath],
		[Comments],
		getdate(), 
		1, 
		getdate(), 
		1
	from
		[T];

	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;
	
	with [T] ([ClassName], [State], [OrdinalPosition], [Name], [Caption], [OverlayImage], [Description]) as 
	(
		select
			T.c.value('../@ClassName', 'varchar(256)'),
			T.c.value('@State', 'tinyint'),
			T.c.value('@OrdinalPosition', 'int'),
			T.c.value('@Name', 'nvarchar(256)'),
			T.c.value('@Caption', 'nvarchar(256)'),
			T.c.value('@OverlayImage', 'varbinary(max)'),
			T.c.value('@Description', 'nvarchar(max)')
		from	
			@data.nodes('Metadata/DocumentType/State') as T(c)
	)
	merge [dbo].[DocumentState] as [target]
	using(	select
				[DocumentType].[Id],
				[T].[State],
				[T].[OrdinalPosition],
				[T].[Name],
				[T].[Caption],
				[T].[OverlayImage],
				[T].[Description]
			from	
				[T] inner join [DocumentType] 
					on ([T].[ClassName] = [DocumentType].[ClassName])) as [source] 
				([DocumentTypeId], [State], [OrdinalPosition], [Name], [Caption], [OverlayImage], [Description])
		on ([target].[DocumentTypeId] = [source].[DocumentTypeId] and [target].[State] = [source].[State])
	when matched then
		update 
		set
			[OrdinalPosition] = [source].[OrdinalPosition],
			[Name] = [source].[Name],
			[Caption] = [source].[Caption],
			[OverlayImage] = [source].[OverlayImage],
			[Description] = [source].[Description]
	when not matched then
		insert
			([DocumentTypeId], [State], [OrdinalPosition], [Name], [Caption], [OverlayImage], [Description], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			([source].[DocumentTypeId], [source].[State], [source].[OrdinalPosition], [source].[Name], [source].[Caption], [source].[OverlayImage], [source].[Description], getdate(), 1, getdate(), 1)
	when not matched by source then
		delete;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DocumentTransitionAccess];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DocumentTransition];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	with [T] ([ClassName], [FileAs], [FromState], [ToState]) as 
	(
		select
			T.c.value('../@ClassName', 'varchar(256)'),
			T.c.value('@FileAs', 'nvarchar(256)'),
			T.c.value('@FromState', 'tinyint'),
			T.c.value('@ToState', 'tinyint')
		from	
			@data.nodes('Metadata/DocumentType/Transition') as T(c)
	),
	[S] ([DocumentTypeId], [FileAs], [FromState], [ToState]) as 
	(
		select
			[DocumentType].[Id],
			[T].[FileAs],
			[T].[FromState],
			[T].[ToState]
		from
			[T] inner join [DocumentType]
				on ([T].[ClassName] = [DocumentType].[ClassName])
	)
	insert into [dbo].[DocumentTransition]
		([State], [FileAs], [DocumentTypeId], [FromState], [ToState], [Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		1,
		[FileAs],
		[DocumentTypeId],
		[FromState],
		[ToState],
		getdate(), 1, getdate(), 1
	from
		[S];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	with [T] ([ClassName], [FromState], [ToState], [Role]) as
	(
		select
			T.c.value('../../@ClassName', 'varchar(256)'),
			T.c.value('../@FromState', 'tinyint'),
			T.c.value('../@ToState', 'tinyint'),
			T.c.value('@Role', 'varchar(256)')
		from	
			@data.nodes('Metadata/DocumentType/Transition/Access') as T(c)
	),
	[S] ([DocumentTransitionId], [ApplicationRoleId]) as
	(
		select
			[DocumentTransition].[Id],
			[ApplicationRole].[Id]
		from	
			[T] inner join [DocumentType]
				on ([T].[ClassName] = [DocumentType].[ClassName])
			inner join [ApplicationRole]
				on ([T].[Role] = [ApplicationRole].[Code])
			inner join [DocumentTransition]
				on ([DocumentType].[Id] = [DocumentTransition].[DocumentTypeId] and [T].[FromState] = [DocumentTransition].[FromState] and [T].[ToState] = [DocumentTransition].[ToState])
	)
	insert into [dbo].[DocumentTransitionAccess]
		([ApplicationRoleId], [DocumentTransitionId])
	select
		[ApplicationRoleId], [DocumentTransitionId]
	from
		[S];
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	commit transaction;
		
	return 0;
end
