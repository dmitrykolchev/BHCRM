create procedure [dbo].[BudgetList] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Budget].[Id],
		[Budget].[State],
		[Budget].[FileAs],
		[Budget].[Number],
		[Budget].[DocumentDate],
		[Budget].[OrganizationId],
		[Budget].[ServiceRequestId],
		[Budget].[BudgetTemplateId],
		[ServiceRequest].[DocumentDate] as [ServiceRequestDocumentDate],
		[ServiceRequest].[Number] as [ServiceRequestNumber],
		[ServiceRequest].[AccountId],
		[ServiceRequest].[VenueProviderId],
		[ServiceRequest].[ReasonId],
		[ServiceRequest].[ServiceRequestTypeId],
		(case when [Budget].[AmountOfGuests] is null then [ServiceRequest].[AmountOfGuests] else [Budget].[AmountOfGuests] end) as [AmountOfGuests],
		[ServiceRequest].[EventDate],
		(case when [Budget].[EventDuration] is null then [ServiceRequest].[EventDuration] else [Budget].[EventDuration] end) as [EventDuration],
		[ServiceRequest].[TradeMarkId],
		[Budget].[Value]
	from
		[dbo].[Budget] inner join [dbo].[ServiceRequest]	
			on ([Budget].[ServiceRequestId] = [ServiceRequest].[Id])
	where
		(@Id is null or [Budget].[Id] = @Id)
		and
		(@AllStates = 1 or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
