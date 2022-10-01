create procedure [dbo].[BudgetItemLinkCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@IncomeBudgetItemId TIdentifier,
			@ExpenseBudgetItemId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@IncomeBudgetItemId = T.c.value('@IncomeBudgetItemId', 'TIdentifier'),
		@ExpenseBudgetItemId = T.c.value('@ExpenseBudgetItemId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('BudgetItemLink') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[BudgetItemLink]
		([State], [FileAs], [IncomeBudgetItemId], [ExpenseBudgetItemId], [Comments], [Created],
		[CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @IncomeBudgetItemId, @ExpenseBudgetItemId, @Comments, getdate(), @UserId,
		getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
