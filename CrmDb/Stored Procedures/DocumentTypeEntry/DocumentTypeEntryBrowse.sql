create procedure [dbo].[DocumentTypeEntryBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[ClassName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterMode],
		[IsNumbered],
		[SmallImage],
		[LargeImage],
		[SupportsTransitionTemplates],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentTypeEntry];

	return 0;
end
