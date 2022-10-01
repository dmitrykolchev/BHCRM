create procedure [dbo].[DocumentLogBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @DocumentTypeId int, @DocumentId int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'int'),
		@DocumentId = T.c.value('DocumentId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[DocumentTypeId],
		[DocumentId],
		[State],
		[FileAs],
		[Number],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentLog]	
	where
		((@DocumentTypeId is null) or ([DocumentTypeId] = @DocumentTypeId))
	and
		((@DocumentId is null) or ([DocumentId] = @DocumentId))
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
