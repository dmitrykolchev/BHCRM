create procedure [dbo].[OpportunityBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @AccountId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[OrganizationId],
		[AssignedToEmployeeId],
		[AccountId],
		[OpportunityTypeId],
		[LeadSourceId],
		[ProjectTypeId],
		[ReasonId],
		[AmountOfGuests],
		[Value],
		[DateClosed],
		[EventDate],
		[Probability],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Opportunity]
	where
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))
	and
		(@AccountId is null or [AccountId] = @AccountId);

	return 0;
end
