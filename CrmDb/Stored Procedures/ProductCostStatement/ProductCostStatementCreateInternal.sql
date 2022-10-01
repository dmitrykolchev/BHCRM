create procedure [dbo].[ProductCostStatementCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ProductCostStatement') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ProductCostStatement]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @Comments, getdate(),
		@UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

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
