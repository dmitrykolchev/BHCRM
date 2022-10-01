create procedure [dbo].[ContractGet] @Id TIdentifier
as
begin
	set nocount on;

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
		[RowVersion],
		(select * from [ContractPaymentCalendar] where [ContractId] = @Id for xml auto, type) as [PaymentCalendar]
	from
		[dbo].[Contract] as [Contract]
	where
		[Id] = @Id
	for xml auto, binary base64;

	return 0;
end
