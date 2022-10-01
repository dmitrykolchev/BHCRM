create procedure [dbo].[EstimatesDocumentChangeState] @Id TIdentifier, @NewState TState, @Data xml
as
begin
	set nocount on;

	declare @Comments nvarchar(max);

	with xmlnamespaces('http://schemas.dykbits.net/bhcrm' as bhcrm)
	select
		@Comments = T.c.value('bhcrm:Comments[1]', 'nvarchar(max)')
	from
		@Data.nodes('bhcrm:EstimatesDocumentChangeStateData') as T(c);

	begin transaction

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[EstimatesDocumentGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'EstimatesDocument', @Id, @NewState, @LogData, @Comments;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	

	update [dbo].[EstimatesDocument]
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
