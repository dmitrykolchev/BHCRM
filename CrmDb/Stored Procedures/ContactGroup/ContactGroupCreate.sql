CREATE PROCEDURE [dbo].[ContactGroupCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[ContactGroupCreateInternal] @xml, @Id out;

	exec @result = [dbo].[ContactGroupGet] @Id;

	return 0;
end
