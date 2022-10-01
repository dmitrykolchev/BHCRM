create procedure [dbo].[AbstractProductUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@FullName nvarchar(1024),
	@ProductTypeId TIdentifier,
	@ProductCategoryId TIdentifier,
	@ProductSubcategoryId TIdentifier,
	@UnitOfMeasureId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[AbstractProduct]
	set
		[FileAs] = @FileAs,
		[FullName] = @FullName,
		[ProductTypeId] = @ProductTypeId,
		[ProductCategoryId] = @ProductCategoryId,
		[ProductSubcategoryId] = @ProductSubcategoryId,
		[UnitOfMeasureId] = @UnitOfMeasureId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	exec [dbo].[AbstractProductGet] @id;

	return 0;
end
