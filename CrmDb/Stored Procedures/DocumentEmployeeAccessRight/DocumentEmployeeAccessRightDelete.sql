create procedure [dbo].[DocumentEmployeeAccessRightDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentEmployeeAccessRight] where [Id] = @Id;

	return 0;
end
