create procedure [dbo].[IndustryDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Industry] where [Id] = @Id;

	return 0;
end
