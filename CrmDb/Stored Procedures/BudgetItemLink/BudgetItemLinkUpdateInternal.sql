create procedure [dbo].[BudgetItemLinkUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@IncomeBudgetItemId TIdentifier,
			@ExpenseBudgetItemId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@IncomeBudgetItemId = T.c.value('@IncomeBudgetItemId', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('@ExpenseBudgetItemId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('BudgetItemLink') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[BudgetItemLink]
	set
		[FileAs] = @FileAs,
		[IncomeBudgetItemId] = @IncomeBudgetItemId,
		[ExpenseBudgetItemId] = @ExpenseBudgetItemId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
