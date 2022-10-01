create procedure [dbo].[CostCenterDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[CostCenter] where [Id] = @Id;

	return 0;
end
