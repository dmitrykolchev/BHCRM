create procedure [dbo].[UnitOfMeasureClassUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@BaseUnitOfMeasureId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[UnitOfMeasureClass]
	set
		[FileAs] = @FileAs,
		[BaseUnitOfMeasureId] = @BaseUnitOfMeasureId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[UnitOfMeasureClassGet] @Id;

	return 0;
end
