CREATE VIEW [dbo].[DocumentViewEntry]
as
	select
		[Id],
		cast(1 as tinyint) as [State],
		[Caption] as [FileAs],
		[ClassName],
		[ViewName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterType] as [DataAdapterMode],
		[Description] as [Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentView];
