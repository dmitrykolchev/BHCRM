create procedure [dbo].[DocumentPropertyMetadataBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[DocumentTypeId],
		[PropertyCategory],
		[PropertyValueType],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentPropertyMetadata];

	return 0;
end
