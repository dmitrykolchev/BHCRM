create procedure [dbo].[ReasonBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[ReasonTypeId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Reason];

	return 0;
end
