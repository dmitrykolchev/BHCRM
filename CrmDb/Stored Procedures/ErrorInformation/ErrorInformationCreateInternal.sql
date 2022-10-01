create procedure [dbo].[ErrorInformationCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ErrorInformation') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ErrorInformation]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
