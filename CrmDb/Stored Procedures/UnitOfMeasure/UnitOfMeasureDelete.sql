create procedure [dbo].[UnitOfMeasureDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[UnitOfMeasure] where [Id] = @Id;

	return 0;
end
