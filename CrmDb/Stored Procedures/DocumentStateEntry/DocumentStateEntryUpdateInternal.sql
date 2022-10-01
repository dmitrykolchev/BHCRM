create procedure [dbo].[DocumentStateEntryUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@DocumentTypeId int,
			@Value TState,
			@OrdinalPosition int,
			@Code TName,
			@FileAs TName,
			@OverlayImage varbinary(max),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@Value = T.c.value('@Value', 'TState'),
		@OrdinalPosition = T.c.value('@OrdinalPosition', 'int'),
		@Code = T.c.value('@Code', 'TName'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@OverlayImage = T.c.value('@OverlayImage', 'varbinary(max)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentStateEntry') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentState]
	set
		[DocumentTypeId] = @DocumentTypeId,
		[State] = @Value,
		[OrdinalPosition] = @OrdinalPosition,
		[Name] = @Code,
		[Caption] = @FileAs,
		[OverlayImage] = @OverlayImage,
		[Description] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
