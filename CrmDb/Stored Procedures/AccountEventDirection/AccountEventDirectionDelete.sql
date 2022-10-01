create procedure [dbo].[AccountEventDirectionDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AccountEventDirection] where [Id] = @Id;

	return 0;
end
