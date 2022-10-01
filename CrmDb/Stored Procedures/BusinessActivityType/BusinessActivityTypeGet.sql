create procedure [dbo].[BusinessActivityTypeGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[BusinessActivityType] as [BusinessActivityType]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
