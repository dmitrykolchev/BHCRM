create procedure [dbo].[CostCenterBrowse] @filter xml
as
begin
	set nocount on;

	declare @AccountId int;

	select
		@AccountId = T.c.value('AccountId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[AccountId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[CostCenter]
	where
		((@AccountId is null) or ([AccountId] = @AccountId))
	and
		(@filter is null or [State] in (select T.c.value('.[1]', 'tinyint')	from @filter.nodes('Filter/State') as T(c)));


	return 0;
end
