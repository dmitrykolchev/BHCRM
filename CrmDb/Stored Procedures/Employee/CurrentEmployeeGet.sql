create procedure [dbo].[CurrentEmployeeGet]
as
begin
	set nocount on;

	declare @CurrentUserId int, @Id TIdentifier;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	select @Id = [Id] from [Employee] where [UserId] = @CurrentUserId;

	exec EmployeeGet @Id;

	return 0;
end
go

grant execute on [dbo].[CurrentEmployeeGet] to public;
go