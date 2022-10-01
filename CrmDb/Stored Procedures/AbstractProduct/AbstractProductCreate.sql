create procedure [dbo].[AbstractProductCreate]
	@FileAs TName,
	@FullName nvarchar(1024),
	@ProductTypeId TIdentifier,
	@ProductCategoryId TIdentifier,
	@ProductSubcategoryId TIdentifier,
	@UnitOfMeasureId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[AbstractProduct]
		([State], [FileAs], [FullName], [ProductTypeId], [ProductCategoryId], [ProductSubcategoryId],
		[UnitOfMeasureId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @FullName, @ProductTypeId, @ProductCategoryId, @ProductSubcategoryId, @UnitOfMeasureId,
		@Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @id = scope_identity();

	exec dbo.AbstractProductGet @id;

	return 0;
end
