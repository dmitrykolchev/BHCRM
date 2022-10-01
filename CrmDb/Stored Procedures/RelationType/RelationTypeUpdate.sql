create procedure [dbo].[RelationTypeUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[RelationTypeUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[RelationTypeGet] @Id;

	return 0;
end
