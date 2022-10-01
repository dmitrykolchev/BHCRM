create procedure [dbo].[OrganizationGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Organization';

	select
		[Id],
		[State],
		[FileAs],
		[FullName],
		[MemberOfAccountId],
		[AccountTypeId],
		[Phone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[WebSite],
		[ProjectTemplateId],
		[ExecutiveId],
		[AccountantId],
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
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select 
			[Id], [BlobId], [BlobName] as [Name] 
		from 
			[DocumentAttachment] as [AttachmentItem] 
		where 
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Organization] as [Organization]
	where
		[Id] = @Id
	for xml auto, binary base64;

	return 0;
end
