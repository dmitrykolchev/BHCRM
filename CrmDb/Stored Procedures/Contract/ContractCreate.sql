create procedure [dbo].[ContractCreate] @xml xml
as
begin
	set nocount on;
	declare @FileAs TName,
			@ParentContractId TIdentifier,
			@Number TCode,
			@ContractDate date,
			@OrganizationId TIdentifier,
			@AccountId TIdentifier,
			@StartDate date,
			@EndDate date,
			@Amount TMoney,
			@VAT TMoney,
			@Comments nvarchar(max)

	declare @Id TIdentifier, @UserId int;

	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@ParentContractId = T.c.value('@ParentContractId', 'int'),
		@Number = T.c.value('@Number', 'varchar(32)'),
		@ContractDate = T.c.value('@ContractDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'int'),
		@AccountId = T.c.value('@AccountId', 'int'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@EndDate = T.c.value('@EndDate', 'date'),
		@Amount = T.c.value('@Amount', 'TMoney'),
		@VAT = T.c.value('@VAT', 'TMoney'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from	
		@xml.nodes('Contract') as T(c);

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Contract]
		([State], [FileAs], [ParentContractId], [Number], [ContractDate], [OrganizationId], [AccountId],
		[StartDate], [EndDate], [Amount], [VAT], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @ParentContractId, @Number, @ContractDate, @OrganizationId, @AccountId, @StartDate,
		@EndDate, @Amount, @VAT, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	insert into [dbo].[ContractPaymentCalendar]
		([ContractId], [PaymentDate], [Amount], [VAT], [Comments])
	select
		@Id,
		T.c.value('@PaymentDate', 'date'),
		T.c.value('@Amount', 'TMoney'),
		T.c.value('@VAT', 'TMoney'),
		T.c.value('@Comments', 'TSubject')
	from	
		@xml.nodes('Contract/PaymentCalendar/ContractPaymentCalendar') as T(c)

	exec [ContractGet] @Id;

	return 0;
end
