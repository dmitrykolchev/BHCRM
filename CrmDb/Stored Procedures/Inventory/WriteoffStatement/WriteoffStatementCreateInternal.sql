create procedure [dbo].[WriteoffStatementCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@Subject TName,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@Subject = T.c.value('@Subject', 'TName'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('WriteoffStatement') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[WriteoffStatement]
		([State], [FileAs], [Number], [DocumentDate], [Subject], [OrganizationId], [StoragePlaceId],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @Subject, @OrganizationId, @StoragePlaceId, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[WriteoffStatementLine]
		([WriteoffStatementId], [ProductId], [Amount], [Cost])
	select
		@Id,
		T.c.value('@ProductId', 'int'),
		T.c.value('@Amount', 'TAmount'),
		T.c.value('@Cost', 'TMoney')
	from	
		@xml.nodes('WriteoffStatement/Lines/WriteoffStatementLine') as T(c)
	if @@error <> 0
		return 1;

	update [dbo].[WriteoffStatement]
	set
		[TotalCost] = (select sum([Amount] * [Cost]) from [dbo].[WriteoffStatementLine] where [WriteoffStatementId] = @Id)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
