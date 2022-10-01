create procedure [dbo].[CountryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Country] where [Id] = @Id;

	return 0;
end
