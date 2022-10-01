create procedure [dbo].[DocumentStateEntryCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@DocumentTypeId int,
			@Value TState,
			@OrdinalPosition int,
			@Code TName,
			@FileAs TName,
			@OverlayImage varbinary(max),
			@Comments nvarchar(max);
	select
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@Value = T.c.value('@Value', 'TState'),
		@OrdinalPosition = T.c.value('@OrdinalPosition', 'int'),
		@Code = T.c.value('@Code', 'TName'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@OverlayImage = T.c.value('@OverlayImage', 'varbinary(max)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DocumentStateEntry') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentState]
		([DocumentTypeId], [State], [OrdinalPosition], [Name], [Caption], [OverlayImage], [Description], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(@DocumentTypeId, @Value, @OrdinalPosition, @Code, @FileAs, @OverlayImage, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
