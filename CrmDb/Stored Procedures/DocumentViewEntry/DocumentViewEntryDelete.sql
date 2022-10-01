create procedure [dbo].[DocumentViewEntryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentView] where [Id] = @Id;

	return 0;
end
