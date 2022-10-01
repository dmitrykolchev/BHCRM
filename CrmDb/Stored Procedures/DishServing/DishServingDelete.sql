create procedure [dbo].[DishServingDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishServing] where [Id] = @Id;

	return 0;
end
