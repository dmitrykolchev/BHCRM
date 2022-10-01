create procedure [dbo].[DocumentPropertyMetadataGet] @Id TIdentifier
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
		[dbo].[DocumentPropertyMetadata]
	where
		[Id] = @Id;

	return 0;
end
