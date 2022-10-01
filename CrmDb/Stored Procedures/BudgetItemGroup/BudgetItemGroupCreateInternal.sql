create procedure [dbo].[BudgetItemGroupCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code TCode,
			@FileAs TName,
			@BudgetItemGroupType int,
			@IsExpenseGroup bit,
			@Comments nvarchar(max);
	select
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BudgetItemGroupType = T.c.value('@BudgetItemGroupType', 'int'),
		@IsExpenseGroup = T.c.value('@IsExpenseGroup', 'bit'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('BudgetItemGroup') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[BudgetItemGroup]
		([State], [Code], [FileAs], [BudgetItemGroupType], [IsExpenseGroup], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @Code, @FileAs, @BudgetItemGroupType, @IsExpenseGroup, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
