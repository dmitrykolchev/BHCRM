create procedure [dbo].[BankAccountGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[AccountId],
		[CashAccount],
		[Bank],
		[Address],
		[Account],
		[SWIFT],
		[ABA],
		[BIC],
		[IBAN],
		[IntermediaryBank],
		[IntermediaryAddress],
		[IntermediaryAccount],
		[IntermediarySWIFT],
		[IntermediaryABA],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[BankAccount]
	where
		[Id] = @Id;

	return 0;
end
