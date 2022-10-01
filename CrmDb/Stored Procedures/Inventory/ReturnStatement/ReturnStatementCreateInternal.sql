create procedure [dbo].[ReturnStatementCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@StoragePlaceId TIdentifier,
			@SalesOrderId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@StoragePlaceId = T.c.value('@StoragePlaceId', 'TIdentifier'),
		@SalesOrderId = T.c.value('@SalesOrderId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ReturnStatement') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ReturnStatement]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [StoragePlaceId], [SalesOrderId], [TotalCost], [TotalPrice],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @StoragePlaceId, @SalesOrderId, 0, 0, @Comments,
		getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

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
		[TotalCost] = isnull((select sum([Amount] * [Cost]) from [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id), 0),
		[TotalPrice] = isnull((select sum([Amount] * [Price]) from [dbo].[ReturnStatementLine] where [ReturnStatementId] = @Id), 0)
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
