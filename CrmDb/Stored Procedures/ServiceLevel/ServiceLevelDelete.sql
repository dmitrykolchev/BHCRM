create procedure [dbo].[ServiceLevelDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ServiceLevel] where [Id] = @Id;

	return 0;
end
