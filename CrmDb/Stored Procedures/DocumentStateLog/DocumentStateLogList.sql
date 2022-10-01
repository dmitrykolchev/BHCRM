create procedure [dbo].[DocumentStateLogList] @filter xml
as
begin
	set nocount on;

	declare @Id TIdentifier;

	select
		@Id = T.c.value('Id[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[DocumentTypeId],
		[DocumentId],
		[FromState],
		[ToState],
		[Comments],
		[Data],
		[Created],
		[CreatedBy]
	from
		[dbo].[DocumentStateLog]
	where
		(@Id is null or [Id] = @Id);

	return 0;
end
