create procedure [dbo].[DishCookingMethodDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishCookingMethod] where [Id] = @Id;

	return 0;
end
