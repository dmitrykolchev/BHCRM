create procedure [dbo].[ItemColorDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ItemColor] where [Id] = @Id;

	return 0;
end
