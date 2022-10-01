create procedure [dbo].[BeveragePackDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BeveragePack] where [Id] = @Id;

	return 0;
end
