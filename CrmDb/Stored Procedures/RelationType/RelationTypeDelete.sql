create procedure [dbo].[RelationTypeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[RelationType] where [Id] = @Id;

	return 0;
end
