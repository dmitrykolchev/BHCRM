create procedure [dbo].[ProductTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProductType] where [Id] = @Id;

	return 0;
end
