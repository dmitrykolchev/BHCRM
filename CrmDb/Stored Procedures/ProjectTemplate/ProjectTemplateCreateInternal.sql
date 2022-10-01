create procedure [dbo].[ProjectTemplateCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@ProjectTypeId TIdentifier,
			@Duration int,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectTypeId = T.c.value('@ProjectTypeId', 'TIdentifier'),
		@Duration = T.c.value('@Duration', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ProjectTemplate') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProjectTemplate]
		([State], [FileAs], [ProjectTypeId], [Duration], [Comments], [Created], [CreatedBy],
		[Modified], [ModifiedBy])
	values
		(1, @FileAs, @ProjectTypeId, @Duration, @Comments, getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
