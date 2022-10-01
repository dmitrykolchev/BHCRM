create procedure [dbo].[PriceListUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ProductCategoryId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ProductCategoryId = T.c.value('@ProductCategoryId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('PriceList') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[PriceList]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[ProductCategoryId] = @ProductCategoryId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[PriceListLine] where [PriceListId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[PriceListLine]
		([PriceListId], [ProductId], [PriceMarginId], [Price])
	select
		@Id,
		T.c.value('@ProductId', 'TIdentifier'),
		T.c.value('@PriceMarginId', 'TIdentifier'),
		T.c.value('@Price', 'TMoney')
	from	
		@xml.nodes('PriceList/Lines/PriceListLine') as T(c);
	if @@error <> 0
		return 1;

	return 0;
end
