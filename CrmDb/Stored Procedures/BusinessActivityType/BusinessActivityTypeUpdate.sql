CREATE PROCEDURE [dbo].[BusinessActivityTypeUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BusinessActivityTypeUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[BusinessActivityTypeGet] @Id;

	return 0;
end
