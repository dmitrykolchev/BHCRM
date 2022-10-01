create procedure [dbo].[LeadGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[AssignedToEmployeeId],
		[FirstName],
		[MiddleName],
		[LastName],
		[Title],
		[Department],
		[AccountName],
		[LeadSourceId],
		[LeadSourceDescription],
		[StatusDescription],
		[BusinessPhone],
		[MobilePhone],
		[HomePhone],
		[OtherPhone],
		[Fax],
		[Email],
		[OtherEmail],
		[WebSite],
		[DontCall],
		[EmailOptOut],
		[InvalidEmail],
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
		[RowVersion]
	from
		[dbo].[Lead]
	where
		[Id] = @Id;

	return 0;
end
