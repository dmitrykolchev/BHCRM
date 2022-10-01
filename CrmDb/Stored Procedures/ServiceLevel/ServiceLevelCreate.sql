create procedure [dbo].[ServiceLevelCreate]
	@FileAs TName,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ServiceLevel]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[ServiceLevelGet] @Id;

	return 0;
end
