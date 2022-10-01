CREATE PROCEDURE [dbo].[DocumentEmployeeAccessRightCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentEmployeeAccessRightCreateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentEmployeeAccessRightGet] @Id;

	return 0;
end
