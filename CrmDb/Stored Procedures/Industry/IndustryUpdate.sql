create procedure [dbo].[IndustryUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Industry]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [RowVersion] = @RowVersion;

	exec [dbo].[IndustryGet] @Id;

	return 0;
end
