create procedure [dbo].[BudgetItemCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code TCode,
			@FileAs TName,
			@BudgetItemGroupId TIdentifier,
			@BudgetItemType int,
			@Comments nvarchar(max);
	select
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemType = T.c.value('@BudgetItemType', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('BudgetItem') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[BudgetItem]
		([State], [Code], [FileAs], [BudgetItemGroupId], [BudgetItemType], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @Code, @FileAs, @BudgetItemGroupId, @BudgetItemType, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	insert into [dbo].[BudgetItemProductCategory]
		([BudgetItemId], [ProductCategoryId])
	select
		@Id,
		T.c.value('@ProductCategoryId', 'int')
	from	
		@xml.nodes('BudgetItem/Lines/ProductCategory') as T(c)


	return 0;
end
