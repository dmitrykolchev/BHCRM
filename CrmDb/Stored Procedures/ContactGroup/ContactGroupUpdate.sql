CREATE PROCEDURE [dbo].[ContactGroupUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[ContactGroupUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[ContactGroupGet] @Id;

	return 0;
end