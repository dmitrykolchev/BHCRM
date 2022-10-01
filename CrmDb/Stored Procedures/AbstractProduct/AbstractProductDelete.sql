create procedure [dbo].[AbstractProductDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AbstractProduct] where [Id] = @Id;

	return 0;
end
