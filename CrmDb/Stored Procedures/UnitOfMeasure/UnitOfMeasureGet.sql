create procedure [dbo].[UnitOfMeasureGet] @Id TIdentifier
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
		[dbo].[UnitOfMeasure]
	where
		[Id] = @Id;

	return 0;
end
