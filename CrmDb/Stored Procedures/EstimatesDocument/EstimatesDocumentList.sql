create procedure [dbo].[EstimatesDocumentList] @filter xml
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
		[EstimatesDocument].[Id],
		[EstimatesDocument].[State],
		[EstimatesDocument].[FileAs],
		[EstimatesDocument].[Number],
		[EstimatesDocument].[DocumentDate],
		[ServiceRequest].[AccountId],
		[ServiceRequest].[VenueProviderId],
		[ServiceRequest].[ReasonId],
		[ServiceRequest].[ServiceRequestTypeId],
		[EstimatesDocument].[OrganizationId],
		[EstimatesDocument].[ServiceRequestId],
		[EstimatesDocument].[VATRateId],
		[EstimatesDocument].[ExtraCostRateId],
		[EstimatesDocument].[Commission],
		[EstimatesDocument].[Margin],
		[EstimatesDocument].[Discount]
	from
		[dbo].[EstimatesDocument] inner join [dbo].[ServiceRequest]
			on ([EstimatesDocument].[ServiceRequestId] = [ServiceRequest].[Id])
	where
		(@Id is null or [EstimatesDocument].[Id] = @Id)
		and
		(@AllStates = 1 or [EstimatesDocument].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
