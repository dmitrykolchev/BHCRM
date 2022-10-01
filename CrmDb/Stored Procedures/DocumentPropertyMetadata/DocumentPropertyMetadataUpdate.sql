create procedure [dbo].[DocumentPropertyMetadataUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@DocumentTypeId int,
	@PropertyCategory nvarchar(256),
	@PropertyValueType int,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentPropertyMetadata]
	set
		[FileAs] = @FileAs,
		[DocumentTypeId] = @DocumentTypeId,
		[PropertyCategory] = @PropertyCategory,
		[PropertyValueType] = @PropertyValueType,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[DocumentPropertyMetadataGet] @Id;

	return 0;
end
