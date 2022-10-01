create procedure [dbo].[DocumentViewEntryGet] @Id TIdentifier
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
		[dbo].[DocumentViewEntry] as [DocumentViewEntry]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
