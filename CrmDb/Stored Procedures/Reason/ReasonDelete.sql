create procedure [dbo].[ReasonDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Reason] where [Id] = @Id;

	return 0;
end
