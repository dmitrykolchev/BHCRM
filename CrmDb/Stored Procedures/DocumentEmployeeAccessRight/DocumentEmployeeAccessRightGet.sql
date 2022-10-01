create procedure [dbo].[DocumentEmployeeAccessRightGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[DocumentTypeId],
		[DocumentId],
		[DocumentAccessTypeId],
		[EmployeeId],
		[StartDate],
		[EndDate],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentEmployeeAccessRight] as [DocumentEmployeeAccessRight]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
