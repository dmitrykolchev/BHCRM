create procedure [dbo].[DocumentMetadataExport]
as
begin
	set nocount on;

	select [dbo].[DocumentMetadataGetFn]();

	return 0;
end

