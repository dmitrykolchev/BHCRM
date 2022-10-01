create procedure [dbo].[UnitOfMeasureClassDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[UnitOfMeasureClass] where [Id] = @Id;

	return 0;
end
