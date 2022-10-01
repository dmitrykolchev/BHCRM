create procedure [dbo].[ProductCostStatementUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('ProductCostStatement') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[ProductCostStatement]
	set
		[FileAs] = @FileAs,
		[Number] = @Number,
		[DocumentDate] = @DocumentDate,
		[OrganizationId] = @OrganizationId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;
	if @@error <> 0
		return 1;

	delete [dbo].[ProductCostStatementLine] where [ProductCostStatementId] = @Id;
	if @@error <> 0
		return 1;

	insert into [dbo].[ProductCostStatementLine]
		([ProductCostStatementId], [ProductId], [Cost])
	select
		@Id,
		T.c.value('@ProductId', 'TIdentifier'),
		T.c.value('@Cost', 'TMoney')
	from	
		@xml.nodes('ProductCostStatement/Lines/ProductCostStatementLine') as T(c);

	if @@error <> 0
		return 1;

	return 0;
end
