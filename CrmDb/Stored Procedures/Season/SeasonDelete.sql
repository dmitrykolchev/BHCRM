create procedure [dbo].[SeasonDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Season] where [Id] = @Id;

	return 0;
end
