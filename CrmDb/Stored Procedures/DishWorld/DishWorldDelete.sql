create procedure [dbo].[DishWorldDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishWorld] where [Id] = @Id;

	return 0;
end
