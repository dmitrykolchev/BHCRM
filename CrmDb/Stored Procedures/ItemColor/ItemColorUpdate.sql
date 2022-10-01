create procedure [dbo].[ItemColorUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@ColorSample int,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ItemColor]
	set
		[FileAs] = @FileAs,
		[ColorSample] = @ColorSample,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[ItemColorGet] @Id;

	return 0;
end
