CREATE PROCEDURE [dbo].[AccountEventTypeCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventTypeCreateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventTypeGet] @Id;

	return 0;
end
