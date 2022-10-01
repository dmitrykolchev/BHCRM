create procedure [dbo].[DocumentTypeEntryDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[DocumentTransitionAccess] where [DocumentTransitionId] in (select [Id] from [DocumentTransition] where [DocumentTypeId] = @Id);
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DocumentTransition] where [DocumentTypeId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DocumentState] where [DocumentTypeId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[DocumentType] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	commit transaction;
	return 0;
end
