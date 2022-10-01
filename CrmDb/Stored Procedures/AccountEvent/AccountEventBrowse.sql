create procedure [dbo].[AccountEventBrowse] @filter xml
as
begin
	set nocount on;

	declare @Presentation varchar(256), @ContextDocumentClass varchar(256);

	select
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
		@ContextDocumentClass = T.c.value('ContextDocumentClass[1]', 'varchar(256)')
	from
		@filter.nodes('/Filter') as T(c);

	if @Presentation = 'AllAccountEvents' or @ContextDocumentClass in ('Employee', 'Account', 'Contact')
		exec [dbo].[AllAccountEventBrowse] @filter;
	else
		exec [dbo].[MyAccountEventBrowse] @filter;

	return 0;
end
