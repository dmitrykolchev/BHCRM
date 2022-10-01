CREATE VIEW [dbo].[DocumentTypeEntry]
as
	select
		[Id],
		cast(1 as tinyint) as [State],
		[Caption] as [FileAs],
		[ClassName],
		[TableName],
		[SchemaName],
		[ClrTypeName],
		[DataAdapterTypeName],
		[DataAdapterType] as [DataAdapterMode],
		[IsNumbered],
		[SmallImage],
		[LargeImage],
		[SupportsTransitionTemplates],
		[Description] as [Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentType];
