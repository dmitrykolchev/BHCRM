create procedure [dbo].[UnitOfMeasureClassCreate]
	@FileAs TName,
	@BaseUnitOfMeasureId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[UnitOfMeasureClass]
		([State], [FileAs], [BaseUnitOfMeasureId], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @BaseUnitOfMeasureId, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[UnitOfMeasureClassGet] @Id;

	return 0;
end
