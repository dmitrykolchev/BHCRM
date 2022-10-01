create procedure [dbo].[ProjectTaskTemplateBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @ProjectTemplateId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@ProjectTemplateId = T.c.value('ProjectTemplateId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[TaskNo],
		[FileAs],
		[ProjectTemplateId],
		[ProjectMemberRoleId],
		[IsMilestone],
		[TaskStartOffset],
		[TaskDuration],
		[Importance],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ProjectTaskTemplate]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		[ProjectTemplateId] = @ProjectTemplateId;

	return 0;
end
