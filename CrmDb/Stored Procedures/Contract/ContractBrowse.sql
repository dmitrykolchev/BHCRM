create procedure [dbo].[ContractBrowse] @filter xml
as
begin
	set nocount on;

	declare @ParentContractId int, @OrganizationId int, @AccountId int, @Id int;

	select
		@ParentContractId = T.c.value('ParentContractId[1]', 'int'),
		@Id = T.c.value('Id[1]', 'int'),
		@OrganizationId = T.c.value('OrganizationId[1]', 'int'),
		@AccountId = T.c.value('AccountId[1]', 'int')
	from	
		@filter.nodes('/Filter') as T(c);

	select
		[Id],
		[State],
		[FileAs],
		[ParentContractId],
		[Number],
		[ContractDate],
		[OrganizationId],
		[AccountId],
		[StartDate],
		[EndDate],
		[Amount],
		[VAT],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Contract]
	where	
		((@ParentContractId is null and [ParentContractId] is null) or ([ParentContractId] = @ParentContractId))
	and
		((@OrganizationId is null) or ([OrganizationId] = @OrganizationId))
	and
		((@AccountId is null) or ([AccountId] = @AccountId))
	and
		((@Id is null) or ([Id] = @Id))
	and
		(@filter is null or [State] in (select T.c.value('.[1]', 'tinyint')	from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
