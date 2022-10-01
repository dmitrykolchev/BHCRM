create procedure [dbo].[ReturnStatementUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@SalesOrderId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@SalesOrderId = T.c.value('@SalesOrderId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ReturnStatement') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ReturnStatement]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[StoragePlaceId] = @StoragePlaceId,
		[SalesOrderId] = @SalesOrderId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	delete [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[ReturnStatementLine]
		([ReturnStatementId], [ProductId], [Amount], [Cost], [Price])
	select
		@Id,
		T.c.value('@ProductId', 'int'),
		T.c.value('@Amount', 'TAmount'),
		T.c.value('@Cost', 'TMoney'),
		T.c.value('@Price', 'TMoney')
	from	
		@xml.nodes('ReturnStatement/Lines/ReturnStatementLine') as T(c)
	where
		T.c.value('@Amount', 'TAmount') > 0;
	if @@error <> 0
		return 1;

	update [dbo].[ReturnStatement]
	set
		[TotalCost] = (select sum([Amount] * [Cost]) from [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id),
		[TotalPrice] = (select sum([Amount] * [Price]) from [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
