create procedure [dbo].[MyAccountEventBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @StartDate date, @EndDate date, @EmployeeId TIdentifier, @Id TIdentifier, @AccountId TIdentifier, @ContactId TIdentifier, 
			@ServiceRequestId TIdentifier, @AccountEventTypeId TIdentifier;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@StartDate = T.c.value('StartDate[1]', 'date'),
		@EndDate = T.c.value('EndDate[1]', 'date'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@AccountId = T.c.value('AccountId[1]', 'TIdentifier'),
		@ContactId = T.c.value('ContactId[1]', 'TIdentifier'),
		@ServiceRequestId = T.c.value('ServiceRequestId[1]', 'TIdentifier'),
		@AccountEventTypeId = T.c.value('AccountEventTypeId[1]', 'TIdentifier')
	from
		@filter.nodes('/Filter') as T(c);

	if(@StartDate is null)
		set @StartDate = cast('0001-01-01' as date);

	if(@EndDate is null)
		set @EndDate = cast('9999-12-31' as date);

	set @EmployeeId = [dbo].[GetCurrentEmployeeId]();

	select
		[AccountEvent].[Id],
		[AccountEvent].[State],
		[AccountEvent].[FileAs],
		[AccountEvent].[AccountEventTypeId],
		[AccountEvent].[AccountEventDirectionId],
		[AccountEvent].[Importance],
		[AccountEvent].[EventStart],
		[AccountEvent].[EventEnd],
		[AccountEvent].[AccountId],
		[AccountEvent].[ContactId],
		[AccountEvent].[ServiceRequestId],
		[ServiceRequest].[Number] as [ServiceRequestNumber],
		[AccountEvent].[EmployeeId],
		[AccountEvent].[Comments],
		[AccountEvent].[Created],
		[AccountEvent].[CreatedBy],
		[AccountEvent].[Modified],
		[AccountEvent].[ModifiedBy],
		[AccountEvent].[RowVersion]
	from
		[dbo].[AccountEvent] left outer join [ServiceRequest]
			on ([AccountEvent].[ServiceRequestId] = [ServiceRequest].[Id])
	where
		([AccountEvent].[EventStart] between @StartDate and @EndDate)
	and
		(@Id is null or [AccountEvent].[Id] = @Id)
	and
		(@AccountEventTypeId is null or [AccountEvent].[AccountEventTypeId] = @AccountEventTypeId)
	and
		([AccountEvent].[EmployeeId] = @EmployeeId)
	and
		(@AccountId is null or [AccountEvent].[AccountId] = @AccountId)
	and
		(@ContactId is null or [AccountEvent].[ContactId] = @ContactId)
	and
		(@ServiceRequestId is null or [AccountEvent].[ServiceRequestId] = @ServiceRequestId)
	and
		(@AllStates = 1 or [AccountEvent].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
