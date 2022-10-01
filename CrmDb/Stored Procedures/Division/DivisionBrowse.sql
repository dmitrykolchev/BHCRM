create procedure [dbo].[DivisionBrowse] @filter xml
as
begin
	set nocount on;

	declare @AccountId int, @AllStates bit;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@AccountId = T.c.value('AccountId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[AccountId],
		[HeadOfDivisionId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Division]	
	where
		((@AccountId is null) or ([AccountId] = @AccountId))
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
