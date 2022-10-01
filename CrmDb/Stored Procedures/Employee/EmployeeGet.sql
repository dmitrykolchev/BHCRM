create procedure [dbo].[EmployeeGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [dbo].[GetDocumentTypeId]('Employee');

	select
		[Id],
		[State],
		[EmployeeAccountId],
		[FileAs],
		[AccountId],
		[TradeMarkId],
		[PositionId],
		[ReportsToEmployeeId],
		[DivisionId],
		[FirstName],
		[MiddleName],
		[LastName],
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
		[UserId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select 
			[EmployeeSalaryId], [EmployeeId], [Value], [CashValue], [ActiveFrom]
		from [EmployeeSalary] where [EmployeeId] = @Id for xml auto, type) as [Salaries],
		(select 
			[Id], [BlobId], [BlobName] as [Name] 
		from 
			[DocumentAttachment] as [AttachmentItem] 
		where 
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Employee] as [Employee]
	where
		[Id] = @Id
	for xml auto, binary base64;

	return 0;
end
