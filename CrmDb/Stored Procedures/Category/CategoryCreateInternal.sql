create procedure [dbo].[CategoryCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Color int,
			@DocumentTypeId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Color = T.c.value('@Color', 'int'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Category') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Category]
		([State], [FileAs], [Color], [DocumentTypeId], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @Color, @DocumentTypeId, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
