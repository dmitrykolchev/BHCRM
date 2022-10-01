create procedure [dbo].[UnitOfMeasureUpdate]
	@Id TIdentifier,
	@UnitOfMeasureClassId TIdentifier,
	@Code TCode,
	@FileAs TName,
	@Multiplier TAmount,
	@Divider TAmount,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[UnitOfMeasure]
	set
		[UnitOfMeasureClassId] = @UnitOfMeasureClassId,
		[Code] = @Code,
		[FileAs] = @FileAs,
		[Multiplier] = @Multiplier,
		[Divider] = @Divider,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[UnitOfMeasureGet] @Id;

	return 0;
end
