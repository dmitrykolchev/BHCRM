create procedure [dbo].[AccessRightBrowse] @filter xml
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[Code],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[AccessRight];

	return 0;
end
