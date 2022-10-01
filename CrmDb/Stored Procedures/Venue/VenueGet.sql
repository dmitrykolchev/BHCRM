create procedure [dbo].[VenueGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Venue';

	select
		[Id],
		[State],
		[FileAs],
		[FullName],
		[MemberOfAccountId],
		[TradeMarkId],
		[AccountTypeId],
		[AccountGroupId],
		[IndustryId],
		[RegionId],
		[Employees],
		[AnnualRevenue],
		[ManagingOrganizationId],
		[AssignedToEmployeeId],
		[AssistantEmployeeId],
		[ExecutiveId],
		[AccountantId],
		[Phone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[WebSite],
		[BillingAddressStreet],
		[BillingAddressCity],
		[BillingAddressRegion],
		[BillingAddressPostalCode],
		[BillingAddressCountry],
		[ShippingAddressStreet],
		[ShippingAddressCity],
		[ShippingAddressRegion],
		[ShippingAddressPostalCode],
		[ShippingAddressCountry],
		[Comments],
		[VenuePlaceId],
		[PrimaryVenueTypeId],
		[SecondaryVenueTypeId],
		[Summer],
		[Winter],
		[MaximumNumberOfGuestsForBanquet],
		[MaximumNumberOfGuestsForReception],
		[CateringTypeId],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select 
			[Id], 
			(case when [MarketingProgramTypeId] is not null then 1 else 0 end) as [Selected] 
		from 
			[MarketingProgramType] as [MarketingProgramTypeSelector] left outer join [AccountMarketingProgramType] 
				on ([MarketingProgramTypeSelector].[Id] = [AccountMarketingProgramType].[MarketingProgramTypeId] and [AccountMarketingProgramType].[AccountId] = @Id and [AccountMarketingProgramType].[ContactId] is null)
		for xml auto, type) as [MarketingProgramTypes],
		(select
			[Id],
			[ReasonTypeId],
			(case when [ReasonId] is not null then 1 else 0 end) as [Selected] 
		from
			[Reason] as [ReasonSelector] left outer join [AccountReason]
				on ([ReasonSelector].[Id] = [AccountReason].[ReasonId] and [AccountReason].[AccountId] = @Id)
		for xml auto, type) as [Reasons],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Venue] as [Venue]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
