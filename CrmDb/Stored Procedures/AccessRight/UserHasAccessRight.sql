create function [dbo].[UserHasAccessRight](@AccessRight varchar(256), @UserId TIdentifier = null) returns bit
as
begin
	if @UserId is null
		set @UserId = [dbo].[GetCurrentUserId]();
	if @UserId = 1
		return 1;
	else
	begin
		if exists(
			select distinct
				[UR].[UserId],
				[AR].[AccessRightId]
			from
				[UserApplicationRole] as [UR] inner join [ApplicationRoleAccessRight] as [AR]
					on ([UR].[ApplicationRoleId] = [AR].[ApplicationRoleId]) 
				inner join [AccessRight] as [R]
					on ([AR].[AccessRightId] = [R].[Id])
			where
				[UR].[UserId] = @UserId and [R].[Code] = @AccessRight)
			return 1;
	end
	return 0;
end
