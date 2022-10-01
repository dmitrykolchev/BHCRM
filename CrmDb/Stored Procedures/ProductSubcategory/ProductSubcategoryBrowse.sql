create procedure [dbo].[ProductSubcategoryBrowse] @filter xml
as
begin
	set nocount on;
	declare @ProductCategoryId int;

	select
		@ProductCategoryId = T.c.value('ProductCategoryId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[ProductCategoryId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ProductSubcategory]
	where
		(@ProductCategoryId is null or @ProductCategoryId = [ProductCategoryId]);

	return 0;
end
