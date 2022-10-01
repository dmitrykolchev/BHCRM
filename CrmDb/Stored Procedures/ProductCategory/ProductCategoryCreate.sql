create procedure [dbo].[ProductCategoryCreate]
	@FileAs TName,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProductCategory]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);
	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	exec [dbo].[ProductCategoryGet] @Id;
	return 0;
end
