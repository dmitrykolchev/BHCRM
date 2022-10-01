	declare @isql nvarchar(max), @usql nvarchar(max), @dsql nvarchar(max);

	set @isql = 'declare updatedDocuments cursor local forward_only read_only for
		select 
			[inserted].[Id], 
			[inserted].[State] as [ToState]
		from 
			[inserted];
					
	declare @Id TIdentifier, @ToState TState, @DocumentTransitionId TIdentifier, @UserId TIdentifier
			
	set @UserId = dbo.GetCurrentUserId();

	open updatedDocuments;
	fetch next from updatedDocuments into @Id, @ToState
	while @@fetch_status = 0
	begin
		set @DocumentTransitionId = null;
		select
			@DocumentTransitionId = [DocumentTransition].[Id]
		from
			[DocumentTransition]
		where
			[FromState] = 0 AND [ToState] = @ToState AND [DocumentTypeId] = @DocumentTypeId;
			
		if @DocumentTransitionId is null
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#TransitionTemplateCouldNotBeFound'', 16, -1)
			rollback transaction;
			return;
		end;
			
		declare @count int;
		with [R] ([Id]) as
		(
			select [ApplicationRoleId] from	[UserApplicationRole] where [UserId] = @UserId
		),
		[A] ([Id]) as
		(
			select [ApplicationRoleId] from [DocumentTransitionAccess] where [DocumentTransitionId] = @DocumentTransitionId
		)
		select @count = count(*) from [R] inner join [A] on ([R].[Id] = [A].[Id]);

		if @count <= 0
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#AccessDenied'', 16, -1)
			rollback transaction;
			return;
		end
		fetch next from updatedDocuments into @Id, @ToState;
	end
	
	close updatedDocuments;
	deallocate updatedDocuments;';

	set @usql = 'declare updatedDocuments cursor local forward_only read_only for
		select 
			[inserted].[Id], 
			[deleted].[State] as [FromState],
			[inserted].[State] as [ToState]
		from 
			[inserted] inner join [deleted]
				ON ([inserted].[Id] = [deleted].[Id]);
					
	declare @Id TIdentifier, @FromState TState, @ToState TState, @DocumentTransitionId TIdentifier,	@UserId TIdentifier
			
	set @UserId = dbo.GetCurrentUserId();

	open updatedDocuments;
	fetch next from updatedDocuments into @Id, @FromState, @ToState
	while @@fetch_status = 0
	begin
		set @DocumentTransitionId = null;
		select
			@DocumentTransitionId = [DocumentTransition].[Id]
		from
			[DocumentTransition]
		where
			[FromState] = @FromState AND [ToState] = @ToState AND [DocumentTypeId] = @DocumentTypeId;
			
		if @DocumentTransitionId is null
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#TransitionTemplateCouldNotBeFound'', 16, -1)
			rollback transaction;
			return;
		end;
			
		declare @count int;
		with [R] ([Id]) as
		(
			select [ApplicationRoleId] from	[UserApplicationRole] where [UserId] = @UserId
		),
		[A] ([Id]) as
		(
			select [ApplicationRoleId] from [DocumentTransitionAccess] where [DocumentTransitionId] = @DocumentTransitionId
		)
		select @count = count(*) from [R] inner join [A] on ([R].[Id] = [A].[Id]);

		if @count <= 0
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#AccessDenied'', 16, -1)
			rollback transaction;
			return;
		end
		fetch next from updatedDocuments into @Id, @FromState, @ToState;
	end
	
	close updatedDocuments;
	deallocate updatedDocuments;';

	set @dsql = 'declare updatedDocuments cursor local forward_only read_only for
		select 
			[deleted].[Id], 
			[deleted].[State] as [FromState]
		from 
			[deleted];
					
	declare @Id TIdentifier, @FromState TState, @DocumentTransitionId TIdentifier, @UserId TIdentifier
			
	set @UserId = dbo.GetCurrentUserId();

	open updatedDocuments;
	fetch next from updatedDocuments into @Id, @FromState
	while @@fetch_status = 0
	begin
		set @DocumentTransitionId = null;
		select
			@DocumentTransitionId = [DocumentTransition].[Id]
		from
			[DocumentTransition]
		where
			[FromState] = @fromState AND [ToState] = 0 AND [DocumentTypeId] = @DocumentTypeId;
			
		if @DocumentTransitionId is null
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#TransitionTemplateCouldNotBeFound'', 16, -1)
			rollback transaction;
			return;
		end;
			
		declare @count int;
		with [R] ([Id]) as
		(
			select [ApplicationRoleId] from	[UserApplicationRole] where [UserId] = @UserId
		),
		[A] ([Id]) as
		(
			select [ApplicationRoleId] from [DocumentTransitionAccess] where [DocumentTransitionId] = @DocumentTransitionId
		)
		select @count = count(*) from [R] inner join [A] on ([R].[Id] = [A].[Id]);

		if @count <= 0
		begin
			close updatedDocuments;
			deallocate updatedDocuments;
			raiserror(''#AccessDenied'', 16, -1)
			rollback transaction;
			return;
		end
		fetch next from updatedDocuments into @Id, @FromState;
	end
	
	close updatedDocuments;
	deallocate updatedDocuments;';

declare cDocuments cursor local fast_forward read_only 
for 
	select 
		[ClassName], [IsNumbered], [TableName], [SupportsTransitionTemplates] 
	from 
		[DocumentType] 
	where 
		[ClassName] not in('Virtual', 'DocumentEmployeeAccessRight', 'DocumentStateLog') 
	order by 
		[ClassName];

open cDocuments;

declare @ClassName varchar(256), @IsNumbered bit, @SupportsTransitionTemplates bit, @sql nvarchar(max), @procName nvarchar(256), @TableName nvarchar(128);

fetch next from cDocuments into @ClassName, @IsNumbered, @TableName, @SupportsTransitionTemplates;
while @@fetch_status = 0
begin
	declare @table nvarchar(256);
	set @table = '[dbo].[' + @ClassName + ']';
	if exists(select * from sys.objects where object_id = object_id(@table) and type = 'U')
	begin
	set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerInsert]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerInsert]';
	set @sql = replace(@sql, '{0}', @ClassName);
	exec [sp_executesql] @sql;
	set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerUpdate]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerUpdate]';
	set @sql = replace(@sql, '{0}', @ClassName);
	exec [sp_executesql] @sql;
	set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerDelete]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerDelete]';
	set @sql = replace(@sql, '{0}', @ClassName);
	exec [sp_executesql] @sql;

	if @IsNumbered = 0
	begin
	set @sql = 'create trigger [dbo].[sys{0}TriggerInsert] on [dbo].[{0}] for insert
as
begin
	set nocount on;
	declare @DocumentTypeId int;
	set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');
	
	if exists(select * from [DocumentType] where [Id] = @DocumentTypeId and [SupportsTransitionTemplates] = 1) and user_name() <> ''InternalUser''
	begin
	{1}
	end;

	insert into [dbo].[DocumentLog]
		([DocumentTypeId], [DocumentId], [State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion])
	select
		@DocumentTypeId, [Id], [State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion]
	from 
		inserted;

	return;
end';
	set @sql = replace(@sql, '{0}', @ClassName);
	set @sql = replace(@sql, '{1}', @isql);
	exec [sp_executesql] @sql;


	set @sql = 'create trigger [dbo].[sys{0}TriggerUpdate] on [dbo].[{0}] for update
as
begin
	set nocount on;
	if @@rowcount = 0
		return;

	declare @DocumentTypeId int;
	set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');

	if exists(select * from [DocumentType] where [Id] = @DocumentTypeId and [SupportsTransitionTemplates] = 1) and user_name() <> ''InternalUser''
	begin
	{1}
	end;

	update [dbo].[DocumentLog]
	set
		[State] = [I].[State],
		[FileAs] = [I].[FileAs],
		[Comments] = [I].[Comments],
		[Modified] = [I].[Modified],
		[ModifiedBy] = [I].[ModifiedBy],
		[RowVersion] = [I].[RowVersion]
	from
		inserted as [I] inner join [dbo].[DocumentLog] as [L]
			on ([I].[Id] = [L].[DocumentId] and [L].[DocumentTypeId] = @DocumentTypeId);
	return;
end';


	set @sql = replace(@sql, '{0}', @ClassName);
	set @sql = replace(@sql, '{1}', @usql);

	exec [sp_executesql] @sql;
	end
	else
	begin
	set @sql = 'create trigger [dbo].[sys{0}TriggerInsert] on [dbo].[{0}] for insert
as
begin
	set nocount on;
	declare @DocumentTypeId int;
	set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');

	if exists(select * from [DocumentType] where [Id] = @DocumentTypeId and [SupportsTransitionTemplates] = 1) and user_name() <> ''InternalUser''
	begin
	{1}
	end;

	insert into [dbo].[DocumentLog]
		([DocumentTypeId], [DocumentId], [State], [FileAs], [Number], [DocumentDate], [OrganizationId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion])
	select
		@DocumentTypeId, [Id], [State], [FileAs], [Number], [DocumentDate], [OrganizationId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion]
	from 
		inserted;

	return;
end';
	set @sql = replace(@sql, '{0}', @ClassName);
	set @sql = replace(@sql, '{1}', @isql);
	exec [sp_executesql] @sql;


	set @sql = 'create trigger [dbo].[sys{0}TriggerUpdate] on [dbo].[{0}] for update
as
begin
	set nocount on;
	declare @DocumentTypeId int;
	set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');

	if exists(select * from [DocumentType] where [Id] = @DocumentTypeId and [SupportsTransitionTemplates] = 1) and user_name() <> ''InternalUser''
	begin
	{1}
	end;

	update [dbo].[DocumentLog]
	set
		[State] = [I].[State],
		[FileAs] = [I].[FileAs],
		[Number] = [I].[Number],
		[DocumentDate] = [I].[DocumentDate],
		[OrganizationId] = [I].[OrganizationId],
		[Comments] = [I].[Comments],
		[Modified] = [I].[Modified],
		[ModifiedBy] = [I].[ModifiedBy],
		[RowVersion] = [I].[RowVersion]
	from
		inserted as [I] inner join [dbo].[DocumentLog] as [L]
			on ([I].[Id] = [L].[DocumentId] and [L].[DocumentTypeId] = @DocumentTypeId);
	return;
end';
	set @sql = replace(@sql, '{0}', @ClassName);
	set @sql = replace(@sql, '{1}', @usql);
	exec [sp_executesql] @sql;
	end

	set @sql = 'create trigger [dbo].[sys{0}TriggerDelete] on [dbo].[{0}] for delete
as
begin
	set nocount on;
	
	declare @DocumentTypeId int;
	
	set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');

	if exists(select * from [DocumentType] where [Id] = @DocumentTypeId and [SupportsTransitionTemplates] = 1) and user_name() <> ''InternalUser''
	begin
	{1}
	end;

	update [dbo].[DocumentLog]
	set
		[State] = 0,
		[Modified] = getdate(),
		[ModifiedBy] = [dbo].[GetCurrentUserId]()
	from
		deleted as [D] inner join [dbo].[DocumentLog] as [L]
			on ([D].[Id] = [L].[DocumentId] and [L].[DocumentTypeId] = @DocumentTypeId);
	return;
end';
	set @sql = replace(@sql, '{0}', @ClassName);
	set @sql = replace(@sql, '{1}', @dsql);

	exec [sp_executesql] @sql;

	set @sql = 'declare @DocumentTypeId int;
set @DocumentTypeId = [dbo].[GetDocumentTypeId](''{0}'');
if not exists(select * from [dbo].[DocumentLog] where [DocumentTypeId] = @DocumentTypeId)
begin
	insert into [dbo].[DocumentLog]
		([DocumentTypeId], [DocumentId], [State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion])
	select
		@DocumentTypeId, [Id], [State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy], [RowVersion]
	from 
		[dbo].[{0}];
end'
	set @sql = replace(@sql, '{0}', @ClassName);
	exec [sp_executesql] @sql;
	end

	fetch next from cDocuments into @ClassName, @IsNumbered, @TableName, @SupportsTransitionTemplates;
end

close cDocuments;
deallocate cDocuments;
go
