CREATE PROCEDURE [dbo].[CalculationStatementTemplateDeleteInternal] @Id TIdentifier
AS
begin
	set nocount on;

	delete [dbo].[CalculationStatementTemplateLine] where [CalculationStatementTemplateId] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[CalculationStatementTemplateSection] where [CalculationStatementTemplateId] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[CalculationStatementTemplate] where [Id] = @Id;
	if @@error <> 0
		return 1;
	
	return 0;
end
