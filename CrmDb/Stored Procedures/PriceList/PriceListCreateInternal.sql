create procedure [dbo].[PriceListCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@ProductCategoryId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ProductCategoryId = T.c.value('@ProductCategoryId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('PriceList') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[PriceList]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [ProductCategoryId], [Comments], [Created], [CreatedBy],
		[Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @ProductCategoryId, @Comments, getdate(), @UserId, getdate(),
		@UserId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

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
