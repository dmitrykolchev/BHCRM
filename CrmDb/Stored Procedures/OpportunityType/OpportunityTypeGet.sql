create procedure [dbo].[OpportunityTypeGet] @Id TIdentifier
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
		[dbo].[OpportunityType]
	where
		[Id] = @Id;

	return 0;
end
