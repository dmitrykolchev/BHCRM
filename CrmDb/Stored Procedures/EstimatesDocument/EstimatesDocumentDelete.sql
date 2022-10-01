create procedure [dbo].[EstimatesDocumentDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	-- start log document state entry	
	declare @result int, @LogData xml;
	set @LogData = [dbo].[EstimatesDocumentGetFn](@Id);
	exec @result = [dbo].[DocumentStateLogCreateInternal] 'EstimatesDocument', @Id, 0, @LogData, null;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end
	-- end log document state entry	

	delete [dbo].[EstimatesDocumentLine] where [EstimatesDocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[EstimatesDocumentSection] where [EstimatesDocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[EstimatesDocument] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
