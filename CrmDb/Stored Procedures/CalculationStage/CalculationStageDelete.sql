create procedure [dbo].[CalculationStageDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[CalculationStage] where [Id] = @Id;

	return 0;
end
