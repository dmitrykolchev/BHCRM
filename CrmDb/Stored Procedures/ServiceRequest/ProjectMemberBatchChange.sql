CREATE PROCEDURE [dbo].[ProjectMemberBatchChange] @xml xml
as
begin
	set nocount on;
	declare @IncludeInProject bit, @EmployeeId TIdentifier, @ProjectMemberRoleId TIdentifier, @ServiceRequestId TIdentifier, @ProjectId TIdentifier,
			@result int;

	select
		@IncludeInProject = T.c.value('@IncludeInProject', 'bit'),
		@EmployeeId = T.c.value('@EmployeeId', 'int'),
		@ProjectMemberRoleId = T.c.value('@ProjectMemberRoleId', 'int')
	from
		@xml.nodes('/ProjectMemberChangeData') as T(c);

	declare @DocumentTypeId int, @UserId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'ServiceRequest';

	set @UserId = [dbo].[GetCurrentUserId]();


	declare serviceRequestId cursor local forward_only fast_forward read_only for
		select
			T.c.value('@Id', 'int')
		from
			@xml.nodes('/ProjectMemberChangeData/ItemIds/ItemId') as T(c);
		
	open serviceRequestId;

	fetch next from serviceRequestId into @ServiceRequestId;
		
	begin transaction;

	while @@fetch_status = 0
	begin
		select @ProjectId = [ProjectId] from [dbo].[ServiceRequest] where [Id] = @ServiceRequestId;
		if @IncludeInProject = 1
		begin
			exec @result = [dbo].[ProjectMemberAdd] @ProjectId, @EmployeeId, @ProjectMemberRoleId;
			if @@error <> 0 or @result <> 0
				goto error;
		end
		else
		begin
			exec @result = [dbo].[ProjectMemberRemove] @ProjectId, @EmployeeId;
			if @@error <> 0 or @result <> 0
				goto error;
		end
		fetch next from serviceRequestId into @ServiceRequestId;
	end
		
	commit transaction;

	close serviceRequestId;
	deallocate serviceRequestId;
	return 0;

error:
	rollback transaction;

	close serviceRequestId;
	deallocate serviceRequestId;
	return 1;
end

go

grant execute on [dbo].[ProjectMemberBatchChange] to [public];
go