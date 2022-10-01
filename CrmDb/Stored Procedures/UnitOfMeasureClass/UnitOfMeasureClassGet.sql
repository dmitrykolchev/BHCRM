create procedure [dbo].[UnitOfMeasureClassGet] @Id TIdentifier
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
		[dbo].[UnitOfMeasureClass]
	where
		[Id] = @Id;

	return 0;
end
