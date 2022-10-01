create procedure [dbo].[DishTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishType] where [Id] = @Id;

	return 0;
end
