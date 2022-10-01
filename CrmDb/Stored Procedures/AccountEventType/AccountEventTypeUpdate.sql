CREATE PROCEDURE [dbo].[AccountEventTypeUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventTypeUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventTypeGet] @Id;

	return 0;
end
