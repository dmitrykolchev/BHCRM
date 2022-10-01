create procedure [dbo].[ProductCategoryUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProductCategory]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;
	
	exec [dbo].[ProductCategoryGet] @Id;

	return 0;
end
