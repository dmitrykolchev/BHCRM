create procedure [dbo].[DocumentStateEntryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentState] where [Id] = @Id;

	return 0;
end
