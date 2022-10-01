create procedure [dbo].[ServiceRequestBrowse] @filter xml
as
begin
	set nocount on;

	declare @Presentation varchar(256), @CurrentEmployeeId TIdentifier;

	select
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from
		@filter.nodes('/Filter') as T(c);

	set @CurrentEmployeeId = [dbo].[GetCurrentEmployeeId]();

	if @Presentation = 'AllServiceRequests'
		exec [dbo].[AllServiceRequestBrowse] @filter;
	else if @Presentation = 'MyServiceRequests'
		exec [dbo].[MyServiceRequestBrowse] @filter;
	else if @Presentation is null
		exec [dbo].[ServiceRequestList];
	return 0;
end
