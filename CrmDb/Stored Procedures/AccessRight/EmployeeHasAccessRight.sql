create function [dbo].[EmployeeHasAccessRight](@AccessRight varchar(256), @EmployeeId TIdentifier)  returns bit
as
begin
	declare @UserId TIdentifier, @result bit;

	if @EmployeeId is null
		set @UserId = [dbo].[GetCurrentUserId]();
	else
		select @UserId = [UserId] from [dbo].[Employee] where [Id] = @EmployeeId;

	if @UserId is null
		return 0;

	select @result = [dbo].[UserHasAccessRight](@AccessRight, @UserId);
	return @result;
end
