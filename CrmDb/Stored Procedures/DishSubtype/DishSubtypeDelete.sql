create procedure [dbo].[DishSubtypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishSubtype] where [Id] = @Id;

	return 0;
end
