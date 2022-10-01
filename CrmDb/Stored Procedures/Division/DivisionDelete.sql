create procedure [dbo].[DivisionDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Division] where [Id] = @Id;

	return 0;
end
