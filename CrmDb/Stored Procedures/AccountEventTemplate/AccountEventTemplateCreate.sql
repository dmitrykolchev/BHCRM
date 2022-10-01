CREATE PROCEDURE [dbo].[AccountEventTemplateCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventTemplateCreateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventTemplateGet] @Id;

	return 0;
end
