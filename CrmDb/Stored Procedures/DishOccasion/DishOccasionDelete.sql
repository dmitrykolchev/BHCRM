create procedure [dbo].[DishOccasionDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishOccasion] where [Id] = @Id;

	return 0;
end
