create procedure [dbo].[UnitOfMeasureCreate]
	@UnitOfMeasureClassId TIdentifier,
	@Code TCode,
	@FileAs TName,
	@Multiplier TAmount,
	@Divider TAmount,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[UnitOfMeasure]
		([State], [UnitOfMeasureClassId], [Code], [FileAs], [Multiplier], [Divider], [Comments], [Created],
		[CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @UnitOfMeasureClassId, @Code, @FileAs, @Multiplier, @Divider, @Comments, getdate(), @UserId,
		getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[UnitOfMeasureGet] @Id;

	return 0;
end
