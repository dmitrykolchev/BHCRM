create procedure [dbo].[ProjectMemberGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[ProjectId],
		[EmployeeId],
		[ProjectMemberRoleId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ProjectMember]
	where
		[Id] = @Id;

	return 0;
end
