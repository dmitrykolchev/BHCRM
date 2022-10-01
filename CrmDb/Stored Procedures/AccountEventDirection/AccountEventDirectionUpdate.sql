CREATE PROCEDURE [dbo].[AccountEventDirectionUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[AccountEventDirectionUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[AccountEventDirectionGet] @Id;

	return 0;
end
