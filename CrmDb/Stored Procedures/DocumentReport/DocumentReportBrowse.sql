create procedure [dbo].[DocumentReportBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256), @DocumentTypeId int, @Code varchar(128);

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@DocumentTypeId = T.c.value('DocumentTypeId[1]', 'int'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@Code = T.c.value('Code[1]', 'varchar(128)')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[Code],
		[FileAs],
		[DocumentTypeId],
		[ReportPath],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentReport]
	where
		(@Id is null or [Id] = @Id)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
		and
		(@DocumentTypeId is null or [DocumentTypeId] = @DocumentTypeId)
		and
		(@Code is null or [Code] = @Code);

	return 0;
end
