create procedure [dbo].[UnitOfMeasureBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[UnitOfMeasureClassId],
		[Code],
		[FileAs],
		[Multiplier],
		[Divider],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[UnitOfMeasure];

	return 0;
end
