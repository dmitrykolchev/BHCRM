create procedure [dbo].[AccountGroupBrowse] @filter xml
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
		[dbo].[AccountGroup];

	return 0;
end
