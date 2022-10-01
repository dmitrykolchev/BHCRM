create procedure [dbo].[ReasonUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@ReasonTypeId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Reason]
	set
		[FileAs] = @FileAs,
		[ReasonTypeId] = @ReasonTypeId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[ReasonGet] @Id;

	return 0;
end
