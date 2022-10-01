create procedure [dbo].[GLAccountCreate]
	@FileAs TName,
	@Code TCode,
	@ParentId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[GLAccount]
		([State], [FileAs], [Code], [ParentId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Code, @ParentId, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[GLAccountGet] @Id;

	return 0;
end
