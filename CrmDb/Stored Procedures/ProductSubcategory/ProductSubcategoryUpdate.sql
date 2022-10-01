create procedure [dbo].[ProductSubcategoryUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@ProductCategoryId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProductSubcategory]
	set
		[FileAs] = @FileAs,
		[ProductCategoryId] = @ProductCategoryId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	exec [dbo].[ProductSubcategoryGet] @Id;

	return 0;
end
