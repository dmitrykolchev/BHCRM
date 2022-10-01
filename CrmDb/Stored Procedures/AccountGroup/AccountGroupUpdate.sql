CREATE PROCEDURE [dbo].[AccountGroupUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountGroupUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountGroupGet] @Id;

	return 0;
end