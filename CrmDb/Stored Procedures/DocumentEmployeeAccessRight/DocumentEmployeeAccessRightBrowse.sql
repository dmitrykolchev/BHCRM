create procedure [dbo].[DocumentEmployeeAccessRightBrowse] @filter xml
as
begin
	set nocount on;

	declare @DocumentTypeId int, @DocumentId int, @AllStates bit, @EmployeeId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'int'),
		@DocumentId = T.c.value('DocumentId[1]', 'int'),
		@EmployeeId = T.c.value('EmployeeId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[DocumentTypeId],
		[DocumentId],
		[DocumentAccessTypeId],
		[EmployeeId],
		[StartDate],
		[EndDate],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentEmployeeAccessRight]
	where
		([DocumentTypeId] = @DocumentTypeId) and ([DocumentId] = @DocumentId)
	and
		(@EmployeeId is null or [EmployeeId] = @EmployeeId)
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint')	from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
