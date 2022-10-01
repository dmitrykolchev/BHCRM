create procedure [dbo].[ServiceRequestDelete] @Id TIdentifier
as
begin
	set nocount on;
	
	declare @ProjectId TIdentifier;

	select @ProjectId = [ProjectId] from [dbo].[ServiceRequest] where [Id] = @Id;

	begin transaction;

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[ServiceRequestGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'ServiceRequest', @Id, 0, @LogData, null;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	

	delete [dbo].[ServiceRequest] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end
	
	if @ProjectId is not null
	begin
		delete [dbo].[ProjectTask] where [ProjectId] = @ProjectId;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		delete [dbo].[ProjectMember] where [ProjectId] = @ProjectId;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		delete [dbo].[Project] where [Id] = @ProjectId;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end
	
	commit transaction;

	return 0;
end
