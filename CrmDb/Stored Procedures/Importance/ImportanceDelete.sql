create procedure [dbo].[ImportanceDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Importance] where [Id] = @Id;

	return 0;
end
