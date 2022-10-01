create procedure [dbo].[UserNotificationCreateInternal] @EmployeeId TIdentifier, @FileAs TName, @Comments nvarchar(max), @ClassName varchar(256), @DocumentId TIdentifier
as
begin
	set nocount on;

	declare	@DocumentTypeId int,
			@UserId TIdentifier,
			@CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();
	select @UserId = [UserId] from [dbo].[Employee] where [Id] = @EmployeeId;
	if @UserId is null or @CurrentUserId = @UserId
		return 0;

	set @DocumentTypeId = [dbo].[GetDocumentTypeId](@ClassName);

	insert into [dbo].[UserNotification]
		([State], [FileAs], [DocumentTypeId], [DocumentId], [UserId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @DocumentTypeId, @DocumentId, @UserId, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;

	return 0;
end
