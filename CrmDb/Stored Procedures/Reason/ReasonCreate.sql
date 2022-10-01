create procedure [dbo].[ReasonCreate]
	@FileAs TName,
	@ReasonTypeId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Reason]
		([State],
		[FileAs], [ReasonTypeId], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1,
		@FileAs, @ReasonTypeId, @Comments,
		getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[ReasonGet] @Id;

	return 0;
end
