create procedure [dbo].[ItemColorCreate]
	@FileAs TName,
	@ColorSample int,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ItemColor]
		([State], [FileAs], [ColorSample], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @ColorSample, @Comments, getdate(), @UserId, getdate(), @UserId);
	set @Id = scope_identity();

	exec [dbo].[ItemColorGet] @Id;

	return 0;
end
