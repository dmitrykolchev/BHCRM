create procedure [dbo].[ProductSubcategoryGet] @Id TIdentifier
as
begin
	set nocount on;

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
		[Id] = @Id;

	return 0;
end
