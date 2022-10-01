CREATE PROCEDURE [dbo].[AccountEventTemplateUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventTemplateUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventTemplateGet] @Id;

	return 0;
end
