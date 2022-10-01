create procedure [dbo].[ServiceRequestTypeCreate] @xml xml
as
begin
	set nocount on;
	declare @FileAs TName,
			@Comments nvarchar(max);

	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from	
		@xml.nodes('ServiceRequestType') as T(c);

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ServiceRequestType]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[ServiceRequestTypeGet] @Id;


	return 0;
end
