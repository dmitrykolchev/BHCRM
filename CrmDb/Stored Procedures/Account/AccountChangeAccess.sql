CREATE PROCEDURE [dbo].[AccountChangeAccess] @xml xml
as
begin
	set nocount on;
	declare @UpdateAccountManager bit, @AssignedToEmployeeId TIdentifier, @UpdateAssistant bit, @AssistantEmployeeId TIdentifier,
			@DenyAccess bit, @DenyEmployeeId TIdentifier, @AllowAccess bit, @AllowEmployeeId TIdentifier, @DocumentAccessTypeId TIdentifier, @StartDate date, @EndDate date;

	select
		@UpdateAccountManager = T.c.value('@UpdateAccountManager', 'bit'),
		@AssignedToEmployeeId = T.c.value('@AssignedToEmployeeId', 'int'),
		@UpdateAssistant = T.c.value('@UpdateAssistant', 'bit'),
		@AssistantEmployeeId = T.c.value('@AssistantEmployeeId', 'int'),
		@DenyAccess =  T.c.value('@DenyAccess', 'bit'),
		@DenyEmployeeId = T.c.value('@DenyEmployeeId', 'int'),
		@AllowAccess = T.c.value('@AllowAccess', 'bit'),
		@AllowEmployeeId = T.c.value('@AllowEmployeeId', 'int'),
		@DocumentAccessTypeId = T.c.value('@DocumentAccessTypeId', 'int'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@EndDate = T.c.value('@EndDate', 'date')
	from
		@xml.nodes('/AccountChangeAccessData') as T(c);

	declare @DocumentTypeId int, @UserId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Account';

	set @UserId = [dbo].[GetCurrentUserId]();


	begin transaction;

	if @UpdateAccountManager = 1
	begin
		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		delete [dbo].[DocumentEmployeeAccessRight]
		from
			[dbo].[DocumentEmployeeAccessRight] as [D] inner join [I]	
				on ([D].[DocumentTypeId] = @DocumentTypeId and [D].[DocumentId] = [I].[Id] and [D].[EmployeeId] = @AssignedToEmployeeId);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end;

		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		update [dbo].[Account]
		set 
			[AssignedToEmployeeId] = @AssignedToEmployeeId,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		from
			[dbo].[Account] inner join [I]
				on ([Account].[Id] = [I].[Id]);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	if @UpdateAssistant = 1
	begin
		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		delete [dbo].[DocumentEmployeeAccessRight]
		from
			[dbo].[DocumentEmployeeAccessRight] as [D] inner join [I]	
				on ([D].[DocumentTypeId] = @DocumentTypeId and [D].[DocumentId] = [I].[Id] and [D].[EmployeeId] = @AssistantEmployeeId);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end;

		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		update [dbo].[Account]
		set 
			[AssistantEmployeeId] = @AssistantEmployeeId,
			[Modified] = getdate(),
			[ModifiedBy] = @UserId
		from
			[dbo].[Account] inner join [I]
				on ([Account].[Id] = [I].[Id]);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	if @DenyAccess = 1
	begin
		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		delete [dbo].[DocumentEmployeeAccessRight]
		from
			[dbo].[DocumentEmployeeAccessRight] as [D] inner join [I]	
				on ([D].[DocumentTypeId] = @DocumentTypeId and [D].[DocumentId] = [I].[Id] and [D].[EmployeeId] = @DenyEmployeeId);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	if @AllowAccess = 1
	begin
		with [I] ([Id]) as
		(
			select
				T.c.value('@Id', 'int')
			from
				@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c)
		)
		delete [dbo].[DocumentEmployeeAccessRight]
		from
			[dbo].[DocumentEmployeeAccessRight] as [D] inner join [I]	
				on ([D].[DocumentTypeId] = @DocumentTypeId and [D].[DocumentId] = [I].[Id] and [D].[EmployeeId] = @AllowEmployeeId);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		insert into [dbo].[DocumentEmployeeAccessRight]
			([State], [DocumentTypeId], [DocumentId], [DocumentAccessTypeId], [EmployeeId], [StartDate], [EndDate], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			1,
			@DocumentTypeId,
			T.c.value('@Id', 'int'),
			@DocumentAccessTypeId,
			@AllowEmployeeId,
			@StartDate,
			@EndDate,
			getdate(),
			@UserId,
			getdate(),
			@UserId
		from
			@xml.nodes('/AccountChangeAccessData/AccountIds/ItemId') as T(c);
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	commit transaction;

	return 0;
end

