create procedure [dbo].[EmployeeBrowse] @filter xml
as
begin
	set nocount on;

	declare @AllStates bit, @Id TIdentifier, @Presentation varchar(256);

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'TIdentifier'),
		@Presentation = T.c.value('Presentation[1]', 'varchar(256)')
	from
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[IsEmployee],
		[FileAs],
		[AccountId],
		[TradeMarkId],
		[PositionId],
		[ContactGroupId],
		[ContactRoleId],
		[ReportsToEmployeeId],
		[DivisionId],
		[AssignedToEmployeeId],
		[LeadSourceId],
		[Title],
		[Department],
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
		[RowVersion]
	from
		[dbo].[Employee]
	where
		(@Id is null or [Id] = @Id)
		and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
