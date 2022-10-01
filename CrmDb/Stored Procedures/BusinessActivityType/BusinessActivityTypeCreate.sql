CREATE PROCEDURE [dbo].[BusinessActivityTypeCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[BusinessActivityTypeCreateInternal] @xml, @Id out;

	exec @result = [dbo].[BusinessActivityTypeGet] @Id;

	return 0;
end

