create procedure [dbo].[BeverageTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BeverageType] where [Id] = @Id;

	return 0;
end
