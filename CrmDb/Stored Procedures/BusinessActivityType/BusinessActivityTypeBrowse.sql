create procedure [dbo].[BusinessActivityTypeBrowse] @filter xml
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
		[dbo].[BusinessActivityType];

	return 0;
end
