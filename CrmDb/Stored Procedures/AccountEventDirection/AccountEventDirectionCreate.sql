CREATE PROCEDURE [dbo].[AccountEventDirectionCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventDirectionCreateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventDirectionGet] @Id;

	return 0;
end
