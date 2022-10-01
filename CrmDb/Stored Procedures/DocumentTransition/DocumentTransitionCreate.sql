CREATE PROCEDURE [dbo].[DocumentTransitionCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentTransitionCreateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentTransitionGet] @Id;

	return 0;
end
