create procedure [dbo].[OperatingCalculationDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[OperatingBudgetLine] where [DocumentId] = @Id and [DocumentTypeId] = dbo.GetDocumentTypeId('OperatingCalculation');
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[OperatingCalculation] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
