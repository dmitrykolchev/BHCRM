create procedure [dbo].[AbstractProductGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[FullName],
		[ProductTypeId],
		[ProductCategoryId],
		[ProductSubcategoryId],
		[UnitOfMeasureId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[AbstractProduct]
	where
		[Id] = @Id;

	return 0;
end
