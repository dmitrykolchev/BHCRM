create procedure [dbo].[BudgetItemGroupUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code TCode,
			@FileAs TName,
			@BudgetItemGroupType int,
			@IsExpenseGroup bit,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BudgetItemGroupType = T.c.value('@BudgetItemGroupType', 'int'),
		@IsExpenseGroup = T.c.value('@IsExpenseGroup', 'bit'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('BudgetItemGroup') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[BudgetItemGroup]
	set
		[Code] = @Code,
		[FileAs] = @FileAs,
		[BudgetItemGroupType] = @BudgetItemGroupType,
		[IsExpenseGroup] = @IsExpenseGroup,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
