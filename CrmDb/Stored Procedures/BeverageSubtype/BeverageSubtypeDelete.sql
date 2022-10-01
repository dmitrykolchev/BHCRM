create procedure [dbo].[BeverageSubtypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BeverageSubtype] where [Id] = @Id;

	return 0;
end
