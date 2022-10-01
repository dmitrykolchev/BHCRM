create procedure [dbo].[DishDietDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishDiet] where [Id] = @Id;

	return 0;
end
