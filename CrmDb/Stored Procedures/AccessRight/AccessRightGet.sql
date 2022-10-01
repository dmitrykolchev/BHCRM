create procedure [dbo].[AccessRightGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[Code],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select [ApplicationRoleId], [AccessRightId] from [dbo].[ApplicationRoleAccessRight] as [ApplicationRoleAccessRight] where [AccessRightId] = @Id for xml auto, type) as [Roles]
	from
		[dbo].[AccessRight] as [AccessRight]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
