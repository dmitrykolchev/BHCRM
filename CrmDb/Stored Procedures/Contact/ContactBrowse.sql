create procedure [dbo].[ContactBrowse] @filter xml
as
begin
	set nocount on;

	declare @AccountId int, @Id TIdentifier, @Presentation varchar(256);

	select
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from	
		@filter.nodes('/Filter') as T(c);

	if @Presentation = 'MyContacts' and @AccountId is null
	begin
		exec [dbo].[MyContactBrowse] @filter;
	end
	else
	begin
		exec [dbo].[AllContactBrowse] @filter;
	end
	return 0;
end
