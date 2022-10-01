create procedure [dbo].[RelationTypeCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[RelationTypeCreateInternal] @xml, @Id out;

	exec @result = [dbo].[RelationTypeGet] @Id;

	return 0;
end
