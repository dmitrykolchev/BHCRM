create procedure [dbo].[PresentationNodeApplicationRoleBrowse]
as
begin
	set nocount on;
	select
		[PresentationNodeId],
		min([ApplicationRoleId]) as [ApplicationRoleId]
	from
		[PresentationNodeApplicationRole]
	where
		[ApplicationRoleId] in (select [ApplicationRoleId] from [UserApplicationRole] where [UserId] = [dbo].[GetCurrentUserId]())
	group by
		[PresentationNodeId]
	for xml auto, root('ArrayOfPresentationNodeApplicationRole');

	return 0;
end
go

grant execute on [dbo].[PresentationNodeApplicationRoleBrowse] to [public]
go

