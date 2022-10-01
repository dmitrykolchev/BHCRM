create procedure [dbo].[DocumentPropertyMetadataCreate]
	@FileAs TName,
	@DocumentTypeId int,
	@PropertyCategory nvarchar(256),
	@PropertyValueType int,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentPropertyMetadata]
		([State], [FileAs], [DocumentTypeId], [PropertyCategory], [PropertyValueType], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @DocumentTypeId, @PropertyCategory, @PropertyValueType, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[DocumentPropertyMetadataGet] @Id;

	return 0;
end
