create procedure [dbo].[ProductCategoryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProductCategory] where [Id] = @Id;

	return 0;
end
