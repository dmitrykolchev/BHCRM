create procedure [dbo].[DocumentViewEntryBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[ClassName],
		[ViewName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterMode],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentViewEntry];

	return 0;
end
