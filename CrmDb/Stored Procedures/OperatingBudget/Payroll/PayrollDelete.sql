create procedure [dbo].[PayrollDelete] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	set @DocumentTypeId = [dbo].[GetDocumentTypeId]('Payroll');

	begin transaction;

	delete [dbo].[OperatingBudgetLine] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[Payroll] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
