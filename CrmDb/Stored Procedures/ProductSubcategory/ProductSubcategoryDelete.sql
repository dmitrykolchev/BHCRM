create procedure [dbo].[ProductSubcategoryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProductSubcategory] where [Id] = @Id;

	return 0;
end
