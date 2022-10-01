create procedure [dbo].[ServiceRequestTypeUpdate] @xml xml
as
begin
	set nocount on;
	declare @Id TIdentifier,
			@FileAs TName,
			@Comments nvarchar(max),
			@RowVersion timestamp

	select
		@Id = T.c.value('@Id', 'int'),
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from	
		@xml.nodes('ServiceRequestType') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ServiceRequestType]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[ServiceRequestTypeGet] @Id;

	return 0;
end
