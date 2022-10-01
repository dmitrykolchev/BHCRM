create procedure [dbo].[UnitOfMeasureClassBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[BaseUnitOfMeasureId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[UnitOfMeasureClass];

	return 0;
end
