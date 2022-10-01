create procedure [dbo].[ContactDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[ContactGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'Employee', @Id, 0, @LogData, null;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	
	delete [dbo].[Employee] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
