create function [dbo].[ContactGetFn](@Id TIdentifier)
returns xml
as
begin
	declare @DocumentTypeId int;

	select @DocumentTypeId = [dbo].[GetDocumentTypeId]('Contact');

	return (select
		[Id],
		[State],
		[FileAs],
		[ContactGroupId],
		[ContactRoleId],
		[AssignedToEmployeeId],
		[FirstName],
		[MiddleName],
		[LastName],
		[AccountId],
		[ReportsToEmployeeId],
		[LeadSourceId],
		[Title],
		[Department],
		[BirthDate],
		[Gender],
		[BusinessPhone],
		[MobilePhone],
		[HomePhone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[Assistant],
		[AssistantPhone],
		[PrimaryAddressStreet],
		[PrimaryAddressCity],
		[PrimaryAddressRegion],
		[PrimaryAddressPostalCode],
		[PrimaryAddressCountry],
		[AlternateAddressStreet],
		[AlternateAddressCity],
		[AlternateAddressRegion],
		[AlternateAddressPostalCode],
		[AlternateAddressCountry],
		[Comments],
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
				on ([MarketingProgramTypeSelector].[Id] = [AccountMarketingProgramType].[MarketingProgramTypeId] and [AccountMarketingProgramType].[ContactId] = @Id)
		for xml auto, type) as [MarketingProgramTypes],
		(select 
			[Id], [BlobId], [BlobName] as [Name] 
		from 
			[DocumentAttachment] as [AttachmentItem] 
		where 
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Contact] as [Contact]
	where
		[Id] = @Id
	for xml auto, binary base64);
end
