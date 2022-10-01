create procedure [dbo].[BudgetItemUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code TCode,
			@FileAs TName,
			@BudgetItemGroupId TIdentifier,
			@BudgetItemType int,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BudgetItemGroupId = T.c.value('@BudgetItemGroupId', 'TIdentifier'),
		@BudgetItemType = T.c.value('@BudgetItemType', 'int'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('BudgetItem') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[BudgetItem]
	set
		[Code] = @Code,
		[FileAs] = @FileAs,
		[BudgetItemGroupId] = @BudgetItemGroupId,
		[BudgetItemType] = @BudgetItemType,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	delete [dbo].[BudgetItemProductCategory]  where [BudgetItemId] = @Id;

	insert into [dbo].[BudgetItemProductCategory]
		([BudgetItemId], [ProductCategoryId])
	select
		@Id,
		T.c.value('@ProductCategoryId', 'int')
	from	
		@xml.nodes('BudgetItem/Lines/ProductCategory') as T(c)

	return 0;
end
