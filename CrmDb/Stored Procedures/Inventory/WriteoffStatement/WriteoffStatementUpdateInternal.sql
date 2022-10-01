create procedure [dbo].[WriteoffStatementUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@Subject TName,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@Subject = T.c.value('@Subject', 'TName'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('WriteoffStatement') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[WriteoffStatement]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[Subject] = @Subject,
		[OrganizationId] = @OrganizationId,
		[StoragePlaceId] = @StoragePlaceId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	delete [dbo].[WriteoffStatementLine] where [WriteoffStatementId] = @Id;
	if @@error <> 0
		return 1;

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
