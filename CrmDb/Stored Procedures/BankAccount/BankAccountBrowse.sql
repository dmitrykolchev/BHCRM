create procedure [dbo].[BankAccountBrowse] @filter xml
as
begin
	set nocount on;
	declare @AccountId int, @CashAccount bit, @AllStates bit, @Id int;

	select
		@AllStates = T.c.value('AllStates[1]', 'bit'),
		@Id = T.c.value('Id[1]', 'int'),
		@AccountId = T.c.value('AccountId[1]', 'int'),
		@CashAccount = T.c.value('CashAccount[1]', 'bit')
	from	
		@filter.nodes('/Filter') as T(c);

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
		(@AccountId is null or [AccountId] = @AccountId)
	and
		(@Id is null or [Id] = @Id)
	and
		((@CashAccount is null) or ([CashAccount] = @CashAccount))
	and
		(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));

	return 0;
end
