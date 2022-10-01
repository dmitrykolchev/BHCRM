create procedure [dbo].[AccountDelete] @Id TIdentifier
as
begin
	set nocount on;

	if ((select [AccountTypeId] from [Account] where [Id] = @Id) & 0x08) = 0x08
		throw 50489, '#CannotDeleteEmployeeAccount', 1;

	begin transaction;

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[AccountGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'Account', @Id, 0, @LogData, null;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	

	delete [dbo].[Account] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
