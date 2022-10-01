create procedure [dbo].[SizeOfServiceRequestBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[MinimumValue],
		[MaximumValue],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[SizeOfServiceRequest];

	return 0;
end
