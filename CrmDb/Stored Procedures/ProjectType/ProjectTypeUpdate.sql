create procedure [dbo].[ProjectTypeUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProjectType]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [RowVersion] = @RowVersion;

	exec [dbo].[ProjectTypeGet] @Id;

	return 0;
end
