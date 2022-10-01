CREATE PROCEDURE [dbo].[AccountGroupCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountGroupCreateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountGroupGet] @Id;

	return 0;
end
