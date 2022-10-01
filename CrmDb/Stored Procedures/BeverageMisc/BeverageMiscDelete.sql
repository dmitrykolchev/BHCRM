create procedure [dbo].[BeverageMiscDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BeverageMisc] where [Id] = @Id;

	return 0;
end
