CREATE PROCEDURE [dbo].[DocumentTransitionUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentTransitionUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentTransitionGet] @Id;

	return 0;
end
