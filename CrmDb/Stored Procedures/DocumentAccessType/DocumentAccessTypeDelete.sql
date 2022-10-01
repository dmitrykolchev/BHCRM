create procedure [dbo].[DocumentAccessTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentAccessType] where [Id] = @Id;

	return 0;
end
