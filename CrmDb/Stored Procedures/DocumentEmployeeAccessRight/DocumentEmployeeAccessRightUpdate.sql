CREATE PROCEDURE [dbo].[DocumentEmployeeAccessRightUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DocumentEmployeeAccessRightUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[DocumentEmployeeAccessRightGet] @Id;

	return 0;
end
