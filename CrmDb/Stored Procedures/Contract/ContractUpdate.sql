create procedure [dbo].[ContractUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier,
			@FileAs TName,
			@ParentContractId TIdentifier,
			@Number TCode,
			@ContractDate date,
			@OrganizationId TIdentifier,
			@AccountId TIdentifier,
			@StartDate date,
			@EndDate date,
			@Amount TMoney,
			@VAT TMoney,
			@Comments nvarchar(max),
			@RowVersion timestamp

	select
		@Id = T.c.value('@Id', 'int'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from	
		@xml.nodes('Contract') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Contract]
	set
		[FileAs] = @FileAs,
		[ParentContractId] = @ParentContractId,
		[Number] = @Number,
		[ContractDate] = @ContractDate,
		[OrganizationId] = @OrganizationId,
		[AccountId] = @AccountId,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[Amount] = @Amount,
		[VAT] = @VAT,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	delete [dbo].[ContractPaymentCalendar] where [ContractId] = @Id;

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
