create procedure [dbo].[GLAccountUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@Code TCode,
	@ParentId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[GLAccount]
	set
		[FileAs] = @FileAs,
		[Code] = @Code,
		[ParentId] = @ParentId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[GLAccountGet] @Id;

	return 0;
end
