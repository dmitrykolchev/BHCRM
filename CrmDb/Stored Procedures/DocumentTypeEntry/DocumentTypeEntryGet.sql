create procedure [dbo].[DocumentTypeEntryGet] @Id TIdentifier
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
		[dbo].[DocumentTypeEntry] as [DocumentTypeEntry]
	where
		[Id] = @Id
	for xml auto, binary base64;

	return 0;
end
