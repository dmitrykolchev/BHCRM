create procedure [dbo].[ProductSubcategoryCreate]
	@FileAs TName,
	@ProductCategoryId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProductSubcategory]
		([State], [FileAs], [ProductCategoryId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @ProductCategoryId, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	exec [dbo].[ProductSubcategoryGet] @Id;

	return 0;
end
