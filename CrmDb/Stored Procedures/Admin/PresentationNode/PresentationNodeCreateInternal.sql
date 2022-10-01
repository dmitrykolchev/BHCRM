create procedure [dbo].[PresentationNodeCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Key TName,
			@DefaultViewId TIdentifier,
			@ViewControlTypeName varchar(1024),
			@OrdinalPosition int,
			@Parameter TName,
			@ParentId TIdentifier,
			@DocumentTypeId int,
			@SmallImageData varbinary(max),
			@LargeImageData varbinary(max),
			@NodeType int,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Key = T.c.value('@Key', 'TName'),
		@DefaultViewId = T.c.value('@DefaultViewId', 'TIdentifier'),
		@ViewControlTypeName = T.c.value('@ViewControlTypeName', 'varchar(1024)'),
		@OrdinalPosition = T.c.value('@OrdinalPosition', 'int'),
		@Parameter = T.c.value('@Parameter', 'TName'),
		@ParentId = T.c.value('@ParentId', 'TIdentifier'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@SmallImageData = T.c.value('@SmallImageData', 'varbinary(max)'),
		@LargeImageData = T.c.value('@LargeImageData', 'varbinary(max)'),
		@NodeType = T.c.value('@NodeType', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('PresentationNode') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[PresentationNode]
		([State], [FileAs], [Key], [DefaultViewId], [ViewControlTypeName], [OrdinalPosition], [Parameter], [ParentId],
		[DocumentTypeId], [SmallImageData], [LargeImageData], [NodeType], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @Key, @DefaultViewId, @ViewControlTypeName, @OrdinalPosition, @Parameter, @ParentId, @DocumentTypeId,
		@SmallImageData, @LargeImageData, @NodeType, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[PresentationNodeApplicationRole]
		([PresentationNodeId], [ApplicationRoleId])
	select
		@Id,
		T.c.value('@ApplicationRoleId', 'int')
	from	
		@xml.nodes('PresentationNode/Roles/PresentationNodeApplicationRole') as T(c)
	if @@error <> 0
		return 1;

	return 0;
end
