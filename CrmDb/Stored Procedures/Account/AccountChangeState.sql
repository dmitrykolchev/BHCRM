create procedure [dbo].[AccountChangeState] @Id TIdentifier, @NewState TState, @Data xml
as
begin
	set nocount on;

	if ((select [AccountTypeId] from [Account] where [Id] = @Id) & 0x08) = 0x08
		throw 50489, '#CannotChangeEmployeeAccount', 1;

	declare @Comments nvarchar(max);

	with xmlnamespaces('http://schemas.dykbits.net/bhcrm' as bhcrm)
	select
		@Comments = T.c.value('bhcrm:Comments[1]', 'nvarchar(max)')
	from
		@Data.nodes('bhcrm:AccountChangeStateData') as T(c);

	begin transaction

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[AccountGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'Account', @Id, @NewState, @LogData, @Comments;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	

	update [dbo].[Account]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = [dbo].[GetCurrentUserId]()
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
