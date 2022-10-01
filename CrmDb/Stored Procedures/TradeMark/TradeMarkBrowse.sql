create procedure [dbo].[TradeMarkBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id int, @OrganizationId int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'int'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'int')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[BusinessActivityTypeId],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[TradeMark]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@Id is null or [Id] = @Id)
	and
		(@OrganizationId is null or [OrganizationId] = @OrganizationId);

	return 0;
end
