CREATE PROCEDURE [dbo].[CountryUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[CountryUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[CountryGet] @Id;

	return 0;
end
